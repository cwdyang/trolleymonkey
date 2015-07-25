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

        public IList<ShoppingListProduct> GetShoppingList(int id)
        {
            IList<ShoppingList> dbShoppingList = _context.shoppingList.Where(list => list.ShoppingListId == id).ToList();
            List<string> longs = dbShoppingList.Select(list => list.Item.ToString()).ToList();

            return GetShoppingListProducts(longs);
        }

        private IList<ShoppingListProduct> GetShoppingListProducts(IList<string> shoppingListProductIds)
        {
            IList<tbdcProductExtention> tbdcProductExtentions =
                _context.tbdcProductExtentions.Where(x => shoppingListProductIds.Contains(x.NzpnaNo)).ToList();

            var shoppingListProducts = new List<ShoppingListProduct>();
            foreach (var tbdcProduct in tbdcProductExtentions)
            {
                var product = new Product(Convert.ToInt64(tbdcProduct.NzpnaNo), tbdcProduct.ProductDescription, "",
                    tbdcProduct.Unit,
                    Convert.ToDouble(tbdcProduct.grossretailprice));
                
                shoppingListProducts.Add(new ShoppingListProduct(Convert.ToInt32(tbdcProduct.NzpnaNo), 0, product));
            }
            return shoppingListProducts;
        }

    }
}
