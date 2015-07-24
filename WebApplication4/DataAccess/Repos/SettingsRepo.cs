using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repos
{
    public class SettingsRepo
    {
        private readonly IfoodstuffsEntities _context;

        public SettingsRepo()
        {
            _context = new foodstuffsEntities();
        }

        public SettingsRepo(IfoodstuffsEntities context)
        {
            _context = context;
        }


        public Settings Get(int id)
        {
            var tbdcCustomerProfile = _context.tbdcCustomerProfiles.Find(id);
            return new Settings(tbdcCustomerProfile);
        }
    }
}
