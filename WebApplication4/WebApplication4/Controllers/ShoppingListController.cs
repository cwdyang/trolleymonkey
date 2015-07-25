using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Repos;

namespace WebApplication4.Controllers
{
    public class ShoppingListController : ApiController
    {

        private readonly ShoppingListRepo _shoppingListRepo;

        public ShoppingListController()
        {
            _shoppingListRepo = new ShoppingListRepo();
        }

        // GET: api/ShoppingList
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ShoppingList/5
        public IList<ShoppingListProduct> Get(int id)
        {
            return _shoppingListRepo.GetShoppingList(id);
        }

        // POST: api/ShoppingList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShoppingList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShoppingList/5
        public void Delete(int id)
        {
        }
    }
}
