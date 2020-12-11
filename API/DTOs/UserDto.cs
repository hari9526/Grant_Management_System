using System;

namespace API.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public string UserType { get; set; }
        public string Token { get; set; }


    }
}