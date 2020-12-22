using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class ApplicantDetail
    {
      
        public int Id { get; set; }
     
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string State { get; set; }
        public bool Disabled { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Phone { get; set; }
        
    }
}