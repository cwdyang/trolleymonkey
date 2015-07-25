using System.Web.Http;
using DataAccess.Repos;


namespace WebApplication4.Controllers
{

    public class FavouriteListController : ApiController
    {
        private readonly FavouriteListRepo _favListRepo;
        private readonly FSContext _fsContext;

        public FavouriteListController()
        {
            _favListRepo = new FavouriteListRepo();
            _fsContext = new FSContext();;
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            //return  _favListRepo.Get(id);
            
            return _fsContext.GetFavourites(id);
        }   

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}