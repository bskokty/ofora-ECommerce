//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace oforadata.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderItem
    {
        public int id { get; set; }
        public int oid { get; set; }
        public int pid { get; set; }
        public decimal piece { get; set; }
    
        public virtual order order { get; set; }
    }
}
