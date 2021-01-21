using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace models.DbModels
{
    public class State
    {

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        public int Country_Id { get; set; }
        
    }
}