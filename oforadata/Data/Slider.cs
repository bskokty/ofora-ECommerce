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
    
    public partial class Slider
    {
        public int Id { get; set; }
        public string Sliderimage { get; set; }
        public string Yazi { get; set; }
        public Nullable<int> cId { get; set; }
    
        public virtual category category { get; set; }
    }
}
