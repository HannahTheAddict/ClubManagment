using System.ComponentModel.DataAnnotations;

namespace HannahElSayed0523003.DTOs.TeamDTOs
{
    public class GetTeamsDTO
    {
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; } = string.Empty;
        public string City { get; set; }
        public int PlayersCount { get; set; }
    }
}
