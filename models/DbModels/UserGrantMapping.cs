namespace models.DbModels
{
    public class UserGrantMapping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GrantId { get; set; }
        public bool ReviewerStatus {get;set;}
        public string ApplicationStatus {get;set;}
    }
}