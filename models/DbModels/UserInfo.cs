using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        //Email id
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string UserType { get; set; }
        public int CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey("Id")]
        public ApplicantDetail ApplicantDetails{get;set;}
        [ForeignKey("UserId")]
        public ICollection<UserGrantMapping> UserGrantMappings{get;set;}
        [ForeignKey("ApplicantId")]
        public ICollection<EducationDetail> EducationDetails { get; set; }
    }
}