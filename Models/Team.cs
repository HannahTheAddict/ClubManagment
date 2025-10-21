using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.Models
{
    [Index(nameof(TeamName), IsUnique = true)]
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; } = string.Empty;
        public string City { get; set; } 

        //nav
        public Coach coach { get; set; }
        public int CoachID { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Competition> Competitions { get; set; } = new List<Competition>();
    }
}
