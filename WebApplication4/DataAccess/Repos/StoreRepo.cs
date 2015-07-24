using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace DataAccess.Repos
{
    public class StoreRepo
    {
        private readonly IfoodstuffsEntities _context;

        public StoreRepo()
        {
            _context = new foodstuffsEntities();
        }

        public StoreRepo(IfoodstuffsEntities context)
        {
            _context = context;
        }

        public List<Store> GetAll()
        {
            var stores = _context.tbRetailTlogStoresToProcesses.ToList();
            return stores.Select(store => new Store(store)).ToList();
        }

        public Store Get(int id)
        {
            var storesToProcess = _context.tbRetailTlogStoresToProcesses.Find(id);
            return storesToProcess == null ? null : new Store(storesToProcess);
        }
    }
}
