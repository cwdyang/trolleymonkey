using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repos
{
    public class ShoppingListRepo
    {
        private readonly foodstuffsEntities _context;

        public ShoppingListRepo()
        {
            _context = new foodstuffsEntities();
        }

        public IList<ShoppingListProduct> GetShoppingList(string customercardno,int count = 15)
        {
            var shopList = _context.tbdcBasicShopLists.Where(x => x.customercardno == customercardno).ToList().Take(count).ToList();

            //IList<ShoppingList> dbShoppingList = _context.shoppingList.Where(list => list.ShoppingListId == id).ToList();
            //List<string> longs = dbShoppingList.Select(list => list.Item.ToString()).ToList();

            return GetShoppingListProducts(shopList);
        }

        private IList<ShoppingListProduct> GetShoppingListProducts(List<tbdcBasicShopList> shopList)
        { 
          
            var shoppingListProducts = new List<ShoppingListProduct>();
            foreach (var tbdcProductListItem in shopList)
            {
                List<tbdcProductExtention> tbdcProductExtentions =
              _context.tbdcProductExtentions.Where(x => x.NzpnaNo==tbdcProductListItem.nzpnano).ToList();
           
                foreach (var tbdcProduct in tbdcProductExtentions)
                {
                    var product = new ShoppingListProduct(Convert.ToInt64(tbdcProduct.NzpnaNo),
                        tbdcProduct.ProductDescription, string.Format("Static/product-images/{0}.png", tbdcProduct.NzpnaNo),
                        tbdcProduct.Unit,
                        Convert.ToDouble(tbdcProduct.grossretailprice), tbdcProduct.Departmentdescription,
                        tbdcProduct.SubDepartmentDescription, tbdcProduct.HealthRating == "H", tbdcProduct.Food != "N",
                        (int)tbdcProductListItem.avgquantitysold);

                    shoppingListProducts.Add(product);
                }
            }
            return shoppingListProducts;
        }

    }
}
