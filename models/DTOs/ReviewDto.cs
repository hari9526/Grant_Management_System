namespace models.DTOs
{
    public class ReviewDto
    {
        public int Id {get;set;}
        public string ApplicantName { get; set; }
        public string ProgramCode {get;set;}
        public string Country {get;set;}
        public string ApplicationStatus {get;set;}
        public bool ReviewerStatus {get;set;}
    }
}