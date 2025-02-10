using System.ComponentModel.DataAnnotations;

namespace FutbolDataAPI.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
