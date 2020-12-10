using System;   

namespace API.Model
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Email id
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}