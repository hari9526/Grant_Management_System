using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class GrantProgram
    {
         public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ProgramName { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string ProgramCode { get; set; }
        // [Column(TypeName = "Date")]
        public DateTime StartDate {get;set;}
        // [Column(TypeName = "Date")]
        public DateTime EndDate {get;set;}
        public bool Status { get; set; }
        [ForeignKey("GrantId")]
        public ICollection<UserGrantMapping> UserGrantMappings {get;set;}
    }
}