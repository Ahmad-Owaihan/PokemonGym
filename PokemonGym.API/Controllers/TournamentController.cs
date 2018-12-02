using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonGym.API.Data;
using PokemonGym.API.Dtos;
using PokemonGym.API.Models;

namespace PokemonGym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepository _repo;
        private readonly IMapper _mapper;
        public TournamentController(ITournamentRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<IActionResult> GetTournaments()
        {
            var tournaments = await _repo.GetTournaments();
            var tournamentsToReturn = Mapper.Map<IEnumerable<TournamentDto>>(tournaments);
            return Ok(tournamentsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            var tournament = await _repo.GetTournament(id);
            var tournamentToReturn = Mapper.Map<TournamentDto>(tournament);
            return Ok(tournamentToReturn);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TournamentDto tournamentDto)
        {
            var tournament = new Tournament() {
                Name = tournamentDto.Name,
                Date = tournamentDto.Date,
                Participants = new List<Participant>()
            };
            _repo.Add(tournament);
            await _repo.SaveAll();
            return StatusCode(201);
        }

        [HttpPost("join")]
        public async Task<IActionResult> Join(ParticipantDto participantDto)
        {
            if (_repo.GetUser(participantDto.UserId) == null)
                return BadRequest("User Does not exist");
            
            if (_repo.GetTournament(participantDto.TournamentId) == null)
                return BadRequest("Tournament does not exist");
            
            // check if user already joined
            var tournament = await _repo.GetTournament(participantDto.TournamentId);
            var participants = tournament.Participants;
            var participantAlreadyJoined = participants.FirstOrDefault(p => p.UserId == participantDto.UserId);
            if (participantAlreadyJoined != null)
                return BadRequest("Already Joined");

            var participant = new Participant(){
                UserId = participantDto.UserId,
                TournamentId = participantDto.TournamentId,
                Score = 0,
            };

            _repo.Add(participant);
            await _repo.SaveAll();

            return StatusCode(201);

        }

        [HttpDelete("leave")]
        public async Task<IActionResult> Leave(ParticipantDto participantDto)
        {
            if (_repo.GetUser(participantDto.UserId) == null)
                return BadRequest("User Does not exist");

            if (_repo.GetTournament(participantDto.TournamentId) == null)
                return BadRequest("Tournament does not exist");

            var tournament = await _repo.GetTournament(participantDto.TournamentId);
            var participants = tournament.Participants;
            var participantToLeave = participants.FirstOrDefault(p => p.UserId == participantDto.UserId);

            if (participantToLeave == null)
                return BadRequest("You did not Join");

            _repo.Delete(participantToLeave);
            await _repo.SaveAll();

            return StatusCode(202);
        }

        [HttpPost("ScoreRow")]
        public async Task<IActionResult> UpdateScores(ScoreDto scoreDto)
        {
            if (scoreDto.ScoreRow == null)
                return BadRequest("no ScoreRow added");

            var tournament = await _repo.GetTournament(scoreDto.TournamentId);
            if (tournament == null)
                return BadRequest("Tournament does not exist");
            
            var participant = tournament.Participants.SingleOrDefault(x => x.Id == scoreDto.ParticipantId);
            if (participant == null)
                return BadRequest("participant does not exist");

            if (tournament.Scores == null)
                tournament.Scores = new List<ScoreRow>();
            var tournamentScores = tournament.Scores;
            var scoreRow = new List<ScoreNumber>();

            var newScoreRow = new ScoreRow()
            {
                TournamentId = tournament.Id,
                ParticipantId = scoreDto.ParticipantId,
                Row = scoreRow
            };
            foreach (var pt in scoreDto.ScoreRow)
            {
                newScoreRow.Row.Add(pt);
            }
            
            tournamentScores.Add(newScoreRow);

            await _repo.SaveAll();
            
            return StatusCode(201);
        }
    }
}