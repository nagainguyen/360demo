using Libs.Entity;
using static Libs.Repositories.ILoginsRepository;

namespace Libs.Service
{
    public class LoginsService
    {
        private ApplicationDbContext applicationDbContext;
        private LoginsRepository loginsRepository;

        public LoginsService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.loginsRepository = new LoginsRepository(applicationDbContext);
        }
        public void Save()
        {
            this.applicationDbContext.SaveChanges();
        }
        ///
        public void insertLogins(Logins logins)
        {
            loginsRepository.insertLogins(logins);
            Save();
        }
        ///
        public List<Logins> Gettk()
        {
            return applicationDbContext.Logins.ToList();
        }
        //
        public Logins getLogin(string taikhoan)
        {
            return applicationDbContext.Logins.FirstOrDefault(x => x.taikhoan == taikhoan );
        }
        ///
        public void deleteLogins(string taikhoan)
        {
            Logins dn = applicationDbContext.Logins.FirstOrDefault(x => x.taikhoan.Equals(taikhoan));

            loginsRepository.deleteLogins(dn);
            Save();
        }
        //
        public void updateLogin(Logins logins)
        {
            Logins dn = applicationDbContext.Logins.FirstOrDefault(x => x.taikhoan == logins.taikhoan );
            loginsRepository.updateLogins(dn);
            Save();

        }
    }
}