using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class GrantProgram
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ProgramName { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string ProgramCode { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate {get;set;}
        [Column(TypeName = "Date")]
        public DateTime EndDate {get;set;}
        public bool Status { get; set; }

    }
}