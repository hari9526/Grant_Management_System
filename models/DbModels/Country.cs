using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class Country
    {
 
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string PhoneCode { get; set; }
        [ForeignKey("Country_Id")]
        public ICollection<State> States{get;set;}
          
    }
}   