using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DataAccess.Repos;
using DataAccess.ViewModels;

namespace WebApplication4.Controllers
{
    public class StoresController : ApiController
    {
        private readonly StoreRepo _storeRepo;

        public StoresController()
        {
            _storeRepo = new StoreRepo();
        }

        // GET api/<controller>
        public IEnumerable<Store> Get()
        {
            return _storeRepo.GetAll();
        }

        // GET api/<controller>/5
        public Store Get(int id)
        {
            var result = _storeRepo.Get(id);
            if(result ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return _storeRepo.Get(id);
        }
    }
}