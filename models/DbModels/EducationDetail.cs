using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class EducationDetail
    {
        public int Id { get; set; }
        public int ApplicantId {get;set;}
        [Column(TypeName = "nvarchar(30)")]
        public string CourseName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string InstitutionName { get; set; }
        public int YearOfCompletion { get; set; }

    }
}