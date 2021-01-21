using System;

namespace models.DTOs
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }

        public bool? Disabled { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }


    }
}