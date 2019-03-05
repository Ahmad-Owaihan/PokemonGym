namespace PokemonGym.API.Models
{
    public class MemberApplicant
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Club Club { get; set; }
        public int ClubId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}