using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepositoryWrapper _repository;

        public ProfileService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
    
        public void CreateProfile(Profile profile)
        {
            _repository.Profile.Create(profile);
            _repository.Save();
        }

        public async Task<Profile> GetProfileById(int id)
        {
            var profile = await _repository.Profile.GetById(id);
            return profile;
        }

        public async Task<ICollection<Profile>> GetProfiles()
        {
            var profiles = await _repository.Profile.GetAll();
            return profiles;
        }
    }
}
