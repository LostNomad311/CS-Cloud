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
    
    public partial class Log
    {
        public int id { get; set; }
        public System.DateTime Date { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
