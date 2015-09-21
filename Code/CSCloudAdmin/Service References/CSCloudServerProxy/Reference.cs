﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSCloudAdmin.CSCloudServerProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudCommandRecord", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Data")]
    [System.SerializableAttribute()]
    public partial class CSCloudCommandRecord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CSCloudAdmin.CSCloudServerProxy.CSCloudCommandCode CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CSCloudAdmin.CSCloudServerProxy.CSCloudResult ResultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientName {
            get {
                return this.ClientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientNameField, value) != true)) {
                    this.ClientNameField = value;
                    this.RaisePropertyChanged("ClientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CSCloudAdmin.CSCloudServerProxy.CSCloudCommandCode Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CSCloudAdmin.CSCloudServerProxy.CSCloudResult Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudCommandCode", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Enums")]
    public enum CSCloudCommandCode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CONNECT = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        COMPILE = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TEST = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REPORT = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DISCONNECT = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudResult", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Enums")]
    public enum CSCloudResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SUCCESS = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ERROR = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PENDING = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WARNIG = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudClientRecord", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Data")]
    [System.SerializableAttribute()]
    public partial class CSCloudClientRecord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsActiveField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientName {
            get {
                return this.ClientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientNameField, value) != true)) {
                    this.ClientNameField = value;
                    this.RaisePropertyChanged("ClientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudRequest", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Data")]
    [System.SerializableAttribute()]
    public partial class CSCloudRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CSCloudAdmin.CSCloudServerProxy.CSCloudCommand CommandField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientName {
            get {
                return this.ClientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientNameField, value) != true)) {
                    this.ClientNameField = value;
                    this.RaisePropertyChanged("ClientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CSCloudAdmin.CSCloudServerProxy.CSCloudCommand Command {
            get {
                return this.CommandField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandField, value) != true)) {
                    this.CommandField = value;
                    this.RaisePropertyChanged("Command");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudCommand", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Data")]
    [System.SerializableAttribute()]
    public partial class CSCloudCommand : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CSCloudAdmin.CSCloudServerProxy.CSCloudCommandCode CodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CSCloudAdmin.CSCloudServerProxy.CSCloudCommandCode Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CSCloudResponse", Namespace="http://schemas.datacontract.org/2004/07/CSCloud.Data")]
    [System.SerializableAttribute()]
    public partial class CSCloudResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] MessagesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CSCloudAdmin.CSCloudServerProxy.CSCloudRequest RequestField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CSCloudAdmin.CSCloudServerProxy.CSCloudResult ResultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Messages {
            get {
                return this.MessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.MessagesField, value) != true)) {
                    this.MessagesField = value;
                    this.RaisePropertyChanged("Messages");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CSCloudAdmin.CSCloudServerProxy.CSCloudRequest Request {
            get {
                return this.RequestField;
            }
            set {
                if ((object.ReferenceEquals(this.RequestField, value) != true)) {
                    this.RequestField = value;
                    this.RaisePropertyChanged("Request");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CSCloudAdmin.CSCloudServerProxy.CSCloudResult Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CSCloudServerProxy.ICSCloudServer", CallbackContract=typeof(CSCloudAdmin.CSCloudServerProxy.ICSCloudServerCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ICSCloudServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/Connect", ReplyAction="http://tempuri.org/ICSCloudServer/ConnectResponse")]
        bool Connect(string clientName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/Connect", ReplyAction="http://tempuri.org/ICSCloudServer/ConnectResponse")]
        System.Threading.Tasks.Task<bool> ConnectAsync(string clientName, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICSCloudServer/Disconnect")]
        void Disconnect(string ClientName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICSCloudServer/Disconnect")]
        System.Threading.Tasks.Task DisconnectAsync(string ClientName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/GetExecutedCommands", ReplyAction="http://tempuri.org/ICSCloudServer/GetExecutedCommandsResponse")]
        CSCloudAdmin.CSCloudServerProxy.CSCloudCommandRecord[] GetExecutedCommands();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/GetExecutedCommands", ReplyAction="http://tempuri.org/ICSCloudServer/GetExecutedCommandsResponse")]
        System.Threading.Tasks.Task<CSCloudAdmin.CSCloudServerProxy.CSCloudCommandRecord[]> GetExecutedCommandsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/GetClients", ReplyAction="http://tempuri.org/ICSCloudServer/GetClientsResponse")]
        CSCloudAdmin.CSCloudServerProxy.CSCloudClientRecord[] GetClients(bool OnlyActive);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/GetClients", ReplyAction="http://tempuri.org/ICSCloudServer/GetClientsResponse")]
        System.Threading.Tasks.Task<CSCloudAdmin.CSCloudServerProxy.CSCloudClientRecord[]> GetClientsAsync(bool OnlyActive);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICSCloudServerCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/GetName", ReplyAction="http://tempuri.org/ICSCloudServer/GetNameResponse")]
        string GetName();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICSCloudServer/ExecuteCommand", ReplyAction="http://tempuri.org/ICSCloudServer/ExecuteCommandResponse")]
        CSCloudAdmin.CSCloudServerProxy.CSCloudResponse ExecuteCommand(CSCloudAdmin.CSCloudServerProxy.CSCloudRequest command);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICSCloudServerChannel : CSCloudAdmin.CSCloudServerProxy.ICSCloudServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CSCloudServerClient : System.ServiceModel.DuplexClientBase<CSCloudAdmin.CSCloudServerProxy.ICSCloudServer>, CSCloudAdmin.CSCloudServerProxy.ICSCloudServer {
        
        public CSCloudServerClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CSCloudServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CSCloudServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CSCloudServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CSCloudServerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Connect(string clientName, string password) {
            return base.Channel.Connect(clientName, password);
        }
        
        public System.Threading.Tasks.Task<bool> ConnectAsync(string clientName, string password) {
            return base.Channel.ConnectAsync(clientName, password);
        }
        
        public void Disconnect(string ClientName) {
            base.Channel.Disconnect(ClientName);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(string ClientName) {
            return base.Channel.DisconnectAsync(ClientName);
        }
        
        public CSCloudAdmin.CSCloudServerProxy.CSCloudCommandRecord[] GetExecutedCommands() {
            return base.Channel.GetExecutedCommands();
        }
        
        public System.Threading.Tasks.Task<CSCloudAdmin.CSCloudServerProxy.CSCloudCommandRecord[]> GetExecutedCommandsAsync() {
            return base.Channel.GetExecutedCommandsAsync();
        }
        
        public CSCloudAdmin.CSCloudServerProxy.CSCloudClientRecord[] GetClients(bool OnlyActive) {
            return base.Channel.GetClients(OnlyActive);
        }
        
        public System.Threading.Tasks.Task<CSCloudAdmin.CSCloudServerProxy.CSCloudClientRecord[]> GetClientsAsync(bool OnlyActive) {
            return base.Channel.GetClientsAsync(OnlyActive);
        }
    }
}
