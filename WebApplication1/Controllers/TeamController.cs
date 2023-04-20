using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private ITeamRepository _teamRepository;
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

       [HttpGet("all")]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _teamRepository.getTeams());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getTeam(int id)
        {
            return Ok(await _teamRepository.getTeam(id));
        }
        [HttpPost]
        public async Task<IActionResult> createTeam([FromBody] Team team)
        {
            if (team == null) {
                return BadRequest();

            }
            var created = await _teamRepository.createTeam(team);

            return Created("Created", created);
        }
       
    }
}
