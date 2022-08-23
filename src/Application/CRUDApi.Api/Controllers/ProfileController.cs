using CRUDApi.DTOs;
using CRUDApi.Exceptions;
using CRUDApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profile)
        {
            _profileService = profile;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(ProfileCreateDTO newProfile)
        {
            if (newProfile is null)
                return BadRequest("The object created mustn't be empty");
            try
            {
                await _profileService.CreateProfile(newProfile);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Profile doesn't exists");
            }
            return Ok(newProfile);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllProfiles()
        {
            var profiles = await _profileService.GetProfiles();
            if (profiles.Count < 1)
                return NotFound("No one profile is created");
            return Ok(profiles);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(int id)
        {
            var Profile = await _profileService.GetProfileById(id);
            if (Profile is null)
                return NotFound("The requested profile not exists");
            return Ok(Profile);
        }
    }
}
