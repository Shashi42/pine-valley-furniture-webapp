//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S3G2_PVFAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplies
    {
        public int VendorID { get; set; }
        public string MaterialID { get; set; }
        public double SupplyUnitPrice { get; set; }
    
        public virtual Raw_Materials Raw_Materials { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
