using CRUDApi.DTOs;
using CRUDApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CRUDApi.Exceptions;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentTeamsController : ControllerBase
    {
        private readonly IDevelopmentTeamService _developmentTeamService;
        public DevelopmentTeamsController(IDevelopmentTeamService developmentTeamService)
        {
            _developmentTeamService = developmentTeamService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevelopmentTeam(DevelopmentTeamCreateDTO developmentTeam)
        {
            try
            {
                await _developmentTeamService.CreateDevelopmentTeam(developmentTeam);
            }
            catch (MissingScrumMasterException)
            {
                return BadRequest("The team must have 1 employee with Scrum Master profile");
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevelopmentTeams()
        {
            var teams = await _developmentTeamService.GetDevelopmentTeams();
            return Ok(teams);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevelopmentTeamById(int id)
        {
            var team = await _developmentTeamService.GetDevelopmentTeamById(id);
            if(team == null)
                return NotFound();
            return Ok(team);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDevelopmentTeam(DevelopmentTeamUpdateDTO developmentTeam)
        {
            await _developmentTeamService.UpdateDevelopmentTeam(developmentTeam);
            return Ok(developmentTeam);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDevelopmentTeam(int id)
        {
            await _developmentTeamService.DeleteDevelopmentTeam(id);
            return Ok("");
        }
    }
}

