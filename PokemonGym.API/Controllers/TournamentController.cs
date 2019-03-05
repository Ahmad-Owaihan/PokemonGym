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

        [HttpPost("start/{id}")]
        public async Task<IActionResult> StartTournament(int id)
        {
            var tournament = await _repo.GetTournament(id);
            if (tournament == null)
                return BadRequest("Tournament does not exist");

            tournament.HasStarted = true;
            await  _repo.SaveAll();
            return StatusCode(200);
        }

                [HttpPost("stop/{id}")]
        public async Task<IActionResult> StopTournament(int id)
        {
            var tournament = await _repo.GetTournament(id);
            if (tournament == null)
                return BadRequest("Tournament does not exist");

            tournament.HasStarted = false;
            await  _repo.SaveAll();
            return StatusCode(200);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tournament = await _repo.GetTournament(id);
            if (tournament == null)
                return BadRequest("tournament does not exist");
            _repo.Delete(tournament);
            await _repo.SaveAll();
            return StatusCode(202);
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
        public async Task<IActionResult> UpdateScores(ListOfScoreDto listOfScoreDto)
        {
            // remove scoreRow loop since tournament id is all the same, we need one
            foreach(var x in listOfScoreDto.List)
            {
                var tournament = await _repo.GetTournament(x.TournamentId);
                var remove = _repo.RemoveRows(tournament.Id);
                break;
            }
            foreach(var item in listOfScoreDto.List)
            {
                if (item.Row == null)
                    return BadRequest("no ScoreRow added");

                var tournament = await _repo.GetTournament(item.TournamentId);
                if (tournament == null)
                    return BadRequest("Tournament does not exist");
                
                var participant = tournament.Participants.SingleOrDefault(x => x.Id == item.ParticipantId);
                if (participant == null)
                    return BadRequest("participant does not exist");
                
                if (tournament.Scores == null)
                    tournament.Scores = new List<ScoreRow>();

                var tournamentScores = tournament.Scores;
                var scoreRow = new List<ScoreNumber>();

                var newScoreRow = new ScoreRow()
                {
                    TournamentId = tournament.Id,
                    ParticipantId = item.ParticipantId,
                    Row = scoreRow
                };

                tournamentScores.Add(newScoreRow);
                
                foreach (var pt in item.Row)
                {
                    var number = Mapper.Map<ScoreNumber>(pt);
                    newScoreRow.Row.Add(number);
                    await _repo.SaveAll();
                }
                
                
                
                await _repo.SaveAll();
            }
            return StatusCode(201);
        }
    }
}