using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolDataAPI.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        [ForeignKey("Club")]
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}
