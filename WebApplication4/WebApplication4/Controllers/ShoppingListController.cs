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

        

        // GET: api/ShoppingList/5
        [HttpGet]
        public IList<ShoppingListProduct> Get(string id,int count = 15)
        {
            return _shoppingListRepo.GetShoppingList(id, count);
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
