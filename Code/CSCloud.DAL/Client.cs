//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSCloud.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Commands = new HashSet<Command>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Command> Commands { get; set; }
    }
}
