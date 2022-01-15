using System.ComponentModel.DataAnnotations;

namespace MiddleEarthAPI.Data.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
    }
}