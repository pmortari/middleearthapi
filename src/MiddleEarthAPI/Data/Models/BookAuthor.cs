using System.ComponentModel.DataAnnotations;

namespace MiddleEarthAPI.Data.Models
{
    public class BookAuthor
    {
        [Key]
        [Required]
        public int BookAuthorId { get; set; }

        public int AuthorId { get; set; }

        public int RoleId { get; set; }

        public int BookId { get; set; }

        public Author Author { get; set; }

        public Role Role { get; set; }

        public Book Book { get; set; }
    }
}