using System.ComponentModel.DataAnnotations;

namespace HannahElSayed0523003.DTOs.CoachDTOs
{
    public class GetCoachWithDetailsDTO
    {
        public int CoachID { get; set; }
        [Required]
        public string CoachName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        [Required]
        public int ExperienceYears { get; set; }
        public int TeamID {  get; set; }
        public int NumberOfPlayers { get; set; }

    }
}
