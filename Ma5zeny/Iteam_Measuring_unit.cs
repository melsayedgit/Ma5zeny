//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ma5zeny
{
    using System;
    using System.Collections.Generic;
    
    public partial class Iteam_Measuring_unit
    {
        public string Measuring_unit { get; set; }
        public int BarCode { get; set; }
    
        public virtual Iteam Iteam { get; set; }
    }
}