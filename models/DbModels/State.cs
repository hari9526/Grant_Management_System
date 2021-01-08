using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class State
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public int Country_Id { get; set; }
    }
}