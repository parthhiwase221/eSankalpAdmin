//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSankalpAdmin.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class projecttask
    {
        public int Id { get; set; }
        public int stud_id { get; set; }
        public int proj_id { get; set; }
        public string Task { get; set; }
        public System.DateTime date { get; set; }
        public string Status { get; set; }
    }
}
