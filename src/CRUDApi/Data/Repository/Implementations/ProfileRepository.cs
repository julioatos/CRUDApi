using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Implementations
{
    public class ProfileRepository : RepositoryBase<Profile, int>
    {
        public ProfileRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }
    }
}
