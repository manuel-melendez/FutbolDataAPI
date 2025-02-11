namespace FutbolDataAPI.Models.DTOs
{
    public class ClubDTO
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<PlayerDTO> Players { get; set; } = new List<PlayerDTO>();
    }
}
