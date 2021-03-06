﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DataAccess.Repos;
using DataAccess.ViewModels;

namespace WebApplication4.Controllers
{

    public class FavouriteListController : ApiController
    {
        private readonly FavouriteListRepo _favListRepo;

        public FavouriteListController()
        {
            _favListRepo = new FavouriteListRepo();
        }

        // GET api/<controller>
        public IList<Product> Get()
        {
            return new List<Product>();
        }

        // GET api/<controller>/5
        public IList<Product> Get(string id)
        {
            return _favListRepo.Get(id);
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