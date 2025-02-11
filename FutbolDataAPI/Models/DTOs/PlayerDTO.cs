namespace FutbolDataAPI.Models.DTOs
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        public int? ClubId { get; set; }
    }
}
