using System.ComponentModel.DataAnnotations;

namespace MiddleEarthAPI.Data.Models
{
    public class Character
    {
        [Key]
        [Required]
        public int CharacterId { get; set; }
    }
}