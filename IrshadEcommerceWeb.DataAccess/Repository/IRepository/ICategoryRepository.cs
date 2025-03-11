using IrshadEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrshadEcommerce.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //update method is not part of common repo bcas implementation of Update may differ
        void Update(Category obj);
 
    }
}
