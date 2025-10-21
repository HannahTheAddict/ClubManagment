namespace HannahElSayed0523003.DTOs.CompetitionDTOs
{
    public class CompetitionCountDTO
    {
        public string Location { get; set; } = string.Empty;
        public int totalnumberofteams { get; set; }
        //public int totalnumberofplayers { get; set; }

        public List<int> TeamsPlayersNumber { get; set; } = new List<int>();
    }

    public class GetTeamsCountDTO
    {
        public int totalnumberofplayers { get; set; }
    }
}
