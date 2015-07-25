using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class Settings
    {
        public Settings(tbdcCustomerProfile profile)
        {
            Id = profile.ProfileId;
            BudgetUpperLimit = profile.BudgetUpperLimit;
            CustomerCardNo = profile.CustomerCardNo;
            DisplayBudgetMeter = profile.DisplayBudgetMeter;
            DisplayEthicalMeter = profile.DisplayEthicalMeter;
            DisplayShopHealthMeter = profile.DisplayShopHealthMeter;
        }

        public string DisplayShopHealthMeter { get; set; }
        public string DisplayEthicalMeter { get; set; }
        public string DisplayBudgetMeter { get; set; }
        public string CustomerCardNo { get; set; }
        public int? BudgetUpperLimit { get; set; }
        public long Id { get; set; }
    }
}