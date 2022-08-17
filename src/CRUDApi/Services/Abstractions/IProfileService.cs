using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services.Abstractions
{
    public interface IProfileService
    {
        public void CreateProfile(Profile profile);
        public Task<ICollection<Profile>> GetProfiles();
        public Task<Profile> GetProfileById(int id);
    }
}
