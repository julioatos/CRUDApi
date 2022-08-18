using AutoMapper;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.DTOs;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ProfileService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    
        public async Task CreateProfile(ProfileCreateDTO profile)
        {
            _repository.Profile.Create(_mapper.Map<Models.Profile>(profile));
            await _repository.Save();
        }

        public async Task<ProfileReadDTO> GetProfileById(int id)
        {
            var profile = await _repository.Profile.GetById(id);
            return _mapper.Map<ProfileReadDTO>(profile);
        }

        public async Task<ICollection<ProfileReadDTO>> GetProfiles()
        {
            var profile = await _repository.Profile.GetAll();
            return _mapper.Map<ICollection<ProfileReadDTO>>(profile);
        }
    }
}
