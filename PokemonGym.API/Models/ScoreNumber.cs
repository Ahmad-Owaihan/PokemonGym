namespace PokemonGym.API.Models
{
    public class ScoreNumber
    {
        public int Id { get; set; } 
        public int Points { get; set; }
        public ScoreRow ScoreRow { get; set; }
        public int ScoreRowId { get; set; }
    }
}