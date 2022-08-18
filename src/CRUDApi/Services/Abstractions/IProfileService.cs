using CRUDApi.DTOs;
using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services.Abstractions
{
    public interface IProfileService
    {
        public Task CreateProfile(ProfileCreateDTO profile);
        public Task<ICollection<ProfileReadDTO>> GetProfiles();
        public Task<ProfileReadDTO> GetProfileById(int id);
    }
}
