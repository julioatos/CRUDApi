using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Implementations
{
    public class ProfileRepository : RepositoryBase<Profile, int>, IProfileRepository
    {
        public ProfileRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }
    }
}
