using System.ComponentModel.DataAnnotations;

namespace MiddleEarthAPI.Data.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}