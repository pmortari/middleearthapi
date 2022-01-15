using System.ComponentModel.DataAnnotations;

namespace MiddleEarthAPI.Data.Models
{
    public class Publisher
    {
        [Key]
        [Required]
        public int PublisherId { get; set; }

        public string Name { get; set; }
    }
}