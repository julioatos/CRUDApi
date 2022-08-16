namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IRepositoryWrapper 
    {
        IProfileRepository Profile { get; }
        IEmployeeRepository Employee { get; }
        IDevelopmentTeamRepository DevelopmentTeam { get; }

        void Save();
    }
}
