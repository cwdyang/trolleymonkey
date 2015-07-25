using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class Store
    {
        public Store(tbRetailTlogStoresToProcess store)
        {
            Id = store.StoreMembershipNo;
            StoreName = store.StoreNameLong;
        }

        public string StoreName { get; set; }
        public int Id { get; set; }
    }
}