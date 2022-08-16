using CRUDApi.Data.Repository.Abstractions;

namespace CRUDApi.Data.Repository.Implementations
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ScrumTeamContext _context;
        private IProfileRepository _profile;
        private IDevelopmentTeamRepository _developmentTeam;
        private IEmployeeRepository _employee;

        public IProfileRepository Profile
        {
            get
            {
                if (_profile == null)
                    _profile = new ProfileRepository(_context);
                return _profile;
            }

        }
        public IEmployeeRepository Employee
        {
            get
            {
                if(_employee == null)
                    _employee = new EmployeeRepository(_context);
                return _employee;
            }
        }

        public IDevelopmentTeamRepository DevelopmentTeam
        {
            get
            {
                if (_developmentTeam == null)
                    _developmentTeam = new DevelopmentTeamRepository(_context);
                return _developmentTeam;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public RepositoryWrapper(ScrumTeamContext context)
        {
            _context = context;
        }
    }
}
