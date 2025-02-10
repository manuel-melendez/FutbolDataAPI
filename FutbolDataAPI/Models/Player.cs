using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FutbolDataAPI.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int Number { get; set; }
        [ForeignKey("Club")]
        public int? ClubId { get; set; }
        [JsonIgnore]
        public Club? Club { get; set; }
    }
}
