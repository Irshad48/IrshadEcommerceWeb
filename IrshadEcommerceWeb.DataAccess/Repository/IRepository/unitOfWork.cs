using IrshadEcommerce.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrshadEcommerce.DataAccess.Repository.IRepository
{
    public class unitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public unitOfWork(ApplicationDbContext db)
        {
                _db = db;
                Category = new CategoryRepository(_db);
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
