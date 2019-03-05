using System;
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
    public class ClubsController : ControllerBase
    {
        private readonly IClubRepository _repo;
        private readonly IMapper _mapper;
        public ClubsController(IClubRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubDto clubDto)
        {
            var club = new Club() { Name = clubDto.Name };
            _repo.Add(club);
            await _repo.SaveAll();
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var club = await _repo.GetClub(id);
            if (club == null)
                return BadRequest("Club does not exist");

            _repo.Delete(club);
            await _repo.SaveAll();
            return StatusCode(202);
        }

        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await _repo.GetClubs();
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClub(int id)
        {
            var club = await _repo.GetClub(id);
            if (club == null)
                return BadRequest("Club does not exist");
            return Ok(club);
        }

        [HttpPost("applications/apply")]
        public async Task<IActionResult> Apply(MemberApplicantDto memberApplicantDto)
        {
            if (_repo.GetUser(memberApplicantDto.UserId) == null)
                return BadRequest("User Does not exist");

            if (_repo.GetClub(memberApplicantDto.ClubId) == null)
                return BadRequest("Club does not exist");

            // check if member already joined
            var club = await _repo.GetClub(memberApplicantDto.ClubId);
            var applications = await _repo.GetApplicants(memberApplicantDto.ClubId);
            var userAlreadyJoined = applications.FirstOrDefault(a => a.UserId == memberApplicantDto.UserId);
            if (userAlreadyJoined != null)
                return BadRequest("Already Joined this club");
            

            // new applicant
            var applicant = new MemberApplicant()
            {
                UserId = memberApplicantDto.UserId,
                ClubId = memberApplicantDto.ClubId,
                Message = memberApplicantDto.Message
            };

    
            _repo.Add(applicant);
            await _repo.SaveAll();

            return StatusCode(201);

        }

        [HttpDelete("applications/cancel/{id}")]
        public async Task<IActionResult> CancelApplication(int id)
        {
            var application = await _repo.GetApplicant(id);
            if (application == null)
                return BadRequest("application does not exist");

            _repo.Delete(application);
            await _repo.SaveAll();
            return StatusCode(202);
        }

        [HttpPost("applications/accept/{id}")]
        public async Task<IActionResult> AcceptApplication(int id)
        {
            var application = await _repo.GetApplicant(id);
            if (application == null)
                return BadRequest("application does not exist");

            // create new member
            var newMember = new Member(application.UserId, application.ClubId);
            var club = await _repo.GetClub(application.ClubId);
            
            _repo.Add(newMember);
            await _repo.SaveAll();

            // remove applicant from list
            _repo.Delete(application);

            // save changes
            await _repo.SaveAll();

            return StatusCode(202);
            
        }

        [HttpPost("members/kick/{id}")]

        public async Task<IActionResult> KickMember(int id)
        {
            var member = await _repo.GetMember(id);
            if (member == null)
                return BadRequest("Member does not exist");
            _repo.Delete(member);
            await _repo.SaveAll();

            return StatusCode(202);
        }

    }
}
