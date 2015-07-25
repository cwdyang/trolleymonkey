using System.Data.Entity;

namespace DataAccess.Models
{
    public interface IfoodstuffsEntities
    {
        DbSet<tbdcCustomerProfile> tbdcCustomerProfiles { get; set; }
        DbSet<tbdcProductExtention> tbdcProductExtentions { get; set; }
        DbSet<tbRetailTlogStoresToProcess> tbRetailTlogStoresToProcesses { get; set; }
    }
}