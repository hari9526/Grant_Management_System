using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SortName { get; set; }

        public string Name { get; set; }
        public string PhoneCode { get; set; }
        [ForeignKey("Country_Id")]
        public ICollection<State> States{get;set;} 
    }
}