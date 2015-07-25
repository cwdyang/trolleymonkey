using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repos
{
    public class FavouriteListRepo
    {
        private readonly foodstuffsEntities _context;

        public FavouriteListRepo()
        {
            _context = new foodstuffsEntities();
        }

        public FavouriteListRepo(foodstuffsEntities context)
        {
            //_context.Database.SqlQuery<CREATE as Type ToString() macth the data>("dbo.sp", new[] { new SqlParameter("@", "") });
        }

        public FavouritesList Get(long customerCardNumber)
        {
            tbdcPredictItem tbdcPredictItem = _context.tbdcPredictItems.Find(customerCardNumber);
            IList<Product> productList = GetProducts(tbdcPredictItem);

            return new FavouritesList(tbdcPredictItem, productList);
        }

        private Product GetProduct(long inventoryId)
        {
            tbMasterArticleDescription tbMasterArticleDescription = _context.tbMasterArticleDescriptions.Find(inventoryId);
            return new Product(inventoryId, tbMasterArticleDescription.ArticleDescription);
        }

        private IList<Product> GetProducts(tbdcPredictItem item)
        {
            var products = new List<Product>();
            long item1 = Convert.ToInt64(item.Item1);
            long item2 = Convert.ToInt64(item.Item2);
            long item3 = Convert.ToInt64(item.Item3);
            long item4 = Convert.ToInt64(item.Item4);
            long item5 = Convert.ToInt64(item.Item5);
            long item6 = Convert.ToInt64(item.Item6);
            long item7 = Convert.ToInt64(item.Item7);
            long item8 = Convert.ToInt64(item.Item8);
            long item9 = Convert.ToInt64(item.Item9);
            long item10 =Convert.ToInt64(item.Item10);

            products.Add(GetProduct(item1));
            products.Add(GetProduct(item2));
            products.Add(GetProduct(item3));
            products.Add(GetProduct(item4));
            products.Add(GetProduct(item5));
            products.Add(GetProduct(item6));
            products.Add(GetProduct(item7));
            products.Add(GetProduct(item8));
            products.Add(GetProduct(item9));
            products.Add(GetProduct(item10));

            return products;
        } 
    }
}
