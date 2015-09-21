using CSCloud.DAL;
using CSCloud.Data;
using CSCloud.Enums;
using CSCloud.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSCloudServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CSCloudServer : ICSCloudServer
    {
        public const string KEY_PASSWORD = "password";
        public const string KEY_COMMAND_WORKFLOW = "command_workflow";
        public const string KEY_COMMAND_DELAY = "command_delay";

        public readonly string[] CommandWorkFlow;
        public readonly int CommandDelay;

        public event EventHandler<ClientConnectedEventArgs> ClientConnected;
        public event EventHandler<ClientConnectedEventArgs> ClientDisconnected;
        public event EventHandler<CommandSentEventArgs> CommandSent;

        private static CSCloudLogServerProxy.ICSCloudLogService logService;
        private static BindingList<ICSCloudClient> clients = new BindingList<ICSCloudClient>();

        public CSCloudServer()
        {
            CommandWorkFlow = ConfigurationManager.AppSettings[KEY_COMMAND_WORKFLOW].Split(',');
            CommandDelay = int.Parse(ConfigurationManager.AppSettings[KEY_COMMAND_DELAY]);
            logService = new CSCloudLogServerProxy.CSCloudLogServiceClient();

            clients.AllowNew = true;
            clients.AllowRemove = true;
            clients.AllowEdit = false;
            clients.RaiseListChangedEvents = true;
            clients.ListChanged += new ListChangedEventHandler(clients_ListChanged);

            ClientConnected += CSCloudClientConnected;
            CommandSent += CSCloudCommandSent;
        }

        public bool Connect(string clientName, string password)
        {
            CSCloudRequest request = new CSCloudRequest();
            request.ClientName = clientName;
            request.Command = new CSCloudCommand();
            request.Command.Code = CSCloudCommandCode.CONNECT;

            string serverPw = ConfigurationManager.AppSettings[KEY_PASSWORD];
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(clientName)
                || !string.Equals(password, serverPw, StringComparison.InvariantCulture))
            {
                LogRequest(request, CSCloudSeverity.WARNING, "Invalid client credentials.");
                return false;
            }

            // Client authenticated , initialize session

            OperationContext.Current.Channel.Faulted += (sender, args) =>
                {
                    LogRequest(request, CSCloudSeverity.ERROR, string.Format("CLient: {0} has faulted :\n", clientName, args.ToString()));
                    Console.WriteLine("{0} - Client '{1}' connection failed.", DateTime.Now, clientName);
                };
            OperationContext.Current.Channel.Closed += (sender, args) =>
                {
                    LogRequest(request, CSCloudSeverity.ERROR, string.Format("Client: {0} has closed", clientName));
                    Console.WriteLine("{0} - Client '{1}' connection closed.", DateTime.Now, clientName);
                };

            var callback = OperationContext.Current.GetCallbackChannel<ICSCloudClient>();
            if (ClientConnected != null) ClientConnected(this, new ClientConnectedEventArgs(callback));

            return true;
        }

        public void Disconnect(string ClientName)
        {
            var callback = OperationContext.Current.GetCallbackChannel<ICSCloudClient>();
            CSCloudRequest request = new CSCloudRequest();
            request.ClientName = callback.GetName();
            request.Command = new CSCloudCommand();
            request.Command.Code = CSCloudCommandCode.DISCONNECT;
            LogRequest(request, CSCloudSeverity.INFO, string.Format("Client: {0} has disconnected", request.ClientName));

            if (ClientDisconnected != null) ClientDisconnected(this, new ClientConnectedEventArgs(callback));
        }

        /// <summary>
        /// Send the next command in the server's command workflow
        /// </summary>
        /// <param name="client">The client to be sent the command</param>
        /// <param name="command">The current command</param>
        /// <returns>The next command to be executed , of the provided command was the last of the command workflow then null is returned</returns>
        private CSCloudResponse SendNextCommand(ICSCloudClient client, CSCloudCommand command)
        {
            CSCloudResponse response = null;
            int idxCommand = Array.IndexOf(CommandWorkFlow, command.Code.ToString());

            if (idxCommand < CommandWorkFlow.Length - 1)
            {
                // the command is not the last command in the command workflow
                var nextCommand = new CSCloudCommand();
                nextCommand.Code = (CSCloudCommandCode)Enum.Parse(typeof(CSCloudCommandCode), CommandWorkFlow.ElementAt(idxCommand + 1), true);
                response = SendCommand(client, nextCommand);
            }

            return response;
        }

        private CSCloudResponse SendFirstCommand(ICSCloudClient client)
        {
            CSCloudCommand command = new CSCloudCommand();
            command.Code = (CSCloudCommandCode)Enum.Parse(typeof(CSCloudCommandCode), CommandWorkFlow.First(), true);
            return SendCommand(client, command);
        }

        private CSCloudResponse SendCommand(ICSCloudClient client, CSCloudCommand command)
        {
            var request = new CSCloudRequest();
            request.ClientName = client.GetName();
            request.Command = command;
            CSCloudResponse response = null;

            try
            {
                LogRequest(request, CSCloudSeverity.INFO, string.Format("Client: {0} has been sent Command: {1}", client.GetName(), request.ToString()));
                response = client.ExecuteCommand(request);
                LogResponse(response, CSCloudSeverity.INFO);

                if (CommandSent != null) CommandSent(this, new CommandSentEventArgs(client, command));
            }
            catch (Exception ex)
            {
                LogResponse(response, CSCloudSeverity.ERROR, ex.Message, ex.StackTrace);
            }

            return response;
        }

        private void saveResponse(string clientName, CSCloudResponse response)
        {
            try
            {
                using (CSCloudEntities db = new CSCloudEntities())
                {
                    db.Commands.Add(CommandToModel(clientName, response.Request.Command, response.Result));
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }

        private Command CommandToModel(string clientName, CSCloudCommand command, CSCloudResult result)
        {
            var c = new CSCloud.DAL.Command();
            c.Date = DateTime.UtcNow;
            c.Client = new Client { Name = clientName };
            c.Code = command.Code.ToString();
            c.Result = result.ToString();

            return c;
        }

        //public ICSCloudServerCallback Callback
        //{
        //    get
        //    {
        //        return OperationContext.Current.GetCallbackChannel<ICSCloudServerCallback>(); 
        //    }
        //}

        private void CSCloudClientConnected(object sender, ClientConnectedEventArgs args)
        {
            clients.Add(args.ConnectedClient);
        }

        private void CSCloudClientDisconnected(object sender, ClientConnectedEventArgs args)
        {
            bool removed = clients.Remove(args.ConnectedClient);
            Debug.WriteLine(string.Format("Disconnected client removed successfully: {0}", removed));
        }

        private void CSCloudCommandSent(object sender, CommandSentEventArgs args)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(CommandDelay);
                SendNextCommand(args.Client, args.Command);
            });
        }

        private void clients_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                Thread.Sleep(CommandDelay);
                SendFirstCommand(clients[e.NewIndex]);
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                Thread.Sleep(CommandDelay);
                //TODO JBG Has the client already been removed from the list ?
                //TODO JBG logCommand(e.)
            }
        }

        public CSCloudCommandRecord[] GetExecutedCommands()
        {
            using (CSCloudEntities db = new CSCloudEntities())
            {
                var commands = new List<CSCloudCommandRecord>(db.Commands.Count());
                foreach (var c in db.Commands)
                {
                    commands.Add(ModelToCommandRecord(c));
                }

                return commands.ToArray();
            }
        }

        private CSCloudCommandRecord ModelToCommandRecord(Command c)
        {
            return new CSCloudCommandRecord
            {
                ClientName = c.Client.Name,
                Code = (CSCloud.Enums.CSCloudCommandCode)Enum.Parse(typeof(CSCloud.Enums.CSCloudCommandCode), c.Code, true),
                Date = c.Date,
                Result = (CSCloud.Enums.CSCloudResult)Enum.Parse(typeof(CSCloud.Enums.CSCloudResult), c.Result, true),
            };
        }

        public CSCloudClientRecord[] GetClients(bool OnlyActive)
        {
            using (CSCloudEntities db = new CSCloudEntities())
            {
                var dbClients = db.Clients;
                var cls = new List<CSCloudClientRecord>(dbClients.Count());

                foreach (var c in dbClients)
                {
                    cls.Add(CreateClientRecord(c.Name, ((ICommunicationObject)c).State == CommunicationState.Opened));
                }

                return OnlyActive ? cls.Where(c => c.IsActive).ToArray() : cls.ToArray();
            }
        }

        private CSCloudClientRecord CreateClientRecord(string clientName, bool isActive)
        {
            return new CSCloudClientRecord
            {
                ClientName = clientName,
                IsActive = isActive,
            };
        }

        public void LogResponse(CSCloudResponse response, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
        {
            if (logService == null) return;

            try
            {
                if (response == null) throw new ArgumentNullException("response");

                logService.Log(CSCloudLogEntry.FromResponse(response, severity, message, stackTrace));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Could not log response to Log Service: {2}\n{0}\n{1}", ex.Message, ex.StackTrace, response.ToString()));
            }
        }

        public void LogRequest(CSCloudRequest request, CSCloud.Enums.CSCloudSeverity severity, string message = null, string stackTrace = null)
        {
            if (logService == null) return;

            try
            {
                if (request == null) throw new ArgumentNullException("request");

                logService.Log(CSCloudLogEntry.FromRequest(request, severity, message, stackTrace));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Could not log request to Log Service: {2}\n{0}\n{1}", ex.Message, ex.StackTrace, request.ToString()));
            }
        }
    }
}
