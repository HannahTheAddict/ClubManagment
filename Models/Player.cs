using System.ComponentModel.DataAnnotations;
namespace HannahElSayed0523003.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required]
        public string PlayerName { get; set; } = string.Empty;
        public string? Position { get; set; }
        public int Age { get; set; }

        //nav
        public Team Team { get; set; }
        public int TeamID { get; set; }
    }
}
