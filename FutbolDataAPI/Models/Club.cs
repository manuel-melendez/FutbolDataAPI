using System.ComponentModel.DataAnnotations;

namespace FutbolDataAPI.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StadiumName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
