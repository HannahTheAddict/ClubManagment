using System.ComponentModel.DataAnnotations;
using HannahElSayed0523003.Models;

namespace HannahElSayed0523003.DTOs.TeamDTOs
{
    public class CreateTeamDTO
    {
        [Required]
        public string TeamName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        [Required]
        public int CoachID { get; set; }

        //public List<int> Players { get; set; } = new List<int>();
        //public List<int> Competitions { get; set; } = new List<int>();

    }
}
