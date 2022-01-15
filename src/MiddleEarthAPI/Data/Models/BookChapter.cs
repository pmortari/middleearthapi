using System.ComponentModel.DataAnnotations;

namespace MiddleEarthAPI.Data.Models
{
    public class BookChapter
    {
        [Key]
        [Required]
        public int BookChapterId { get; set; }
    }
}