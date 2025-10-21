using System.ComponentModel.DataAnnotations;
namespace HannahElSayed0523003.Models
{
    public class Competition
    {
        [Key]
        public int CompetitionID { get; set; }
        [Required]
        public string CompetitionName { get; set; } = string.Empty;
        public string Location { get; set; }
        public DateTime Date { get; set; }

        //nav
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
