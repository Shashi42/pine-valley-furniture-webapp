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
    
    public partial class Knowledge
    {
        public string EmployeeID { get; set; }
        public string SkillID { get; set; }
        public int Rating { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
