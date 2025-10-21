using System.ComponentModel.DataAnnotations;

namespace HannahElSayed0523003.DTOs.CoachDTOs
{
    public class GetCoachesWithDetailsDTO
    {
        public string Specialization { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
    }
}
