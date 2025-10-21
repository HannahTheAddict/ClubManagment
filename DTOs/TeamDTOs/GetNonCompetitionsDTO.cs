using System.ComponentModel.DataAnnotations;

namespace HannahElSayed0523003.DTOs.TeamDTOs
{
    public class GetNonCompetitionsDTO
    {

        //public List<GetTeamsDTO> Teams { get; set; }
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; } = string.Empty;
        public string City { get; set; }
        public int PlayersCount { get; set; }
    }
}
