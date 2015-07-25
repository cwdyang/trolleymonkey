using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class FavouritesList
    {
        public FavouritesList(tbdcPredictItem tbdcPredictItem, IList<Product> products)
        {
            Id = tbdcPredictItem.Id;
            ProductList = products;
        }

        public float Id { get; set; }
        public IList<Product> ProductList { get; set; }
    }
}
