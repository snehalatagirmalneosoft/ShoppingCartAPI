//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCartAPI.ModelEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exception
    {
        public int ExceptionId { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionDetails { get; set; }
        public string ExceptionFileName { get; set; }
        public string Method { get; set; }
        public Nullable<System.DateTime> ExceptionDateTime { get; set; }
        public Nullable<bool> ExceptionStatus { get; set; }
    }
}
