using System.ComponentModel.DataAnnotations;

namespace HannahElSayed0523003.Models
{
    public class Coach
    {
        [Key]
        public int CoachID { get; set; }
        [Required]
        public string CoachName { get; set; } = string.Empty;
        public string Specialization {  get; set; } = string.Empty;
        [Required]
        public int ExperienceYears { get; set; }

        //nav
        public Team Team { get; set; }

    }
}
