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
    
    public partial class stockStatus
    {
        public int Id { get; set; }
        public int pId { get; set; }
    
        public virtual product product { get; set; }
    }
}