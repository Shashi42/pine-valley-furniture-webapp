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
    
    public partial class Business
    {
        public string CustomerID { get; set; }
        public int TerritoryID { get; set; }
        public string BusinessValue { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
