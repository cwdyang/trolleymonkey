using System.Data.Entity;

namespace DataAccess.Models
{
    public interface IfoodstuffsEntities
    {
        DbSet<tbdcCustomerProfile> tbdcCustomerProfiles { get; set; }
        DbSet<tbdcProductExtention> tbdcProductExtentions { get; set; }
        DbSet<tbRetailTlogStoresToProcess> tbRetailTlogStoresToProcesses { get; set; }

        // Shopping List
        DbSet<tbMasterArticleDescription> tbMasterArticleDescriptions { get; set; }
        DbSet<tbMasterArticleDepartment> tbMasterArticleDepartments { get; set; }
        DbSet<tbdcPredictItem> tbdcPredictItems { get; set; }
        DbSet<tbdcInventory> tbdcInventories { get; set; }
        DbSet<ShoppingList> shoppingList { get; set; }
    }
}