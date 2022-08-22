using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IRepositoryWrapper 
    {
        IProfileRepository Profile { get; }
        IEmployeeRepository Employee { get; }
        IDevelopmentTeamRepository DevelopmentTeam { get; }

        Task Save();
    }
}
