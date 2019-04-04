using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Vega.Domain.Models
{
    [Table("Models")]
    public class Model
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
//        [JsonIgnore]
        public Make Make { get; set; }
        
        public int MakeId { get; set; }
    }
}