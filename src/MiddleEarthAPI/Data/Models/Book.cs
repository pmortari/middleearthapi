using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleEarthAPI.Data.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime OriginalReleaseDate { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public ICollection<BookAuthor> Authors { get; set; }

        [Required]
        public Publisher Publisher { get; set; }
    }
}