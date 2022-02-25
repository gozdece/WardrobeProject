using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> CategoryWithProducts(int categoryId)
        {
           var result = await _appDbContext.Categories.Include(x => x.Products).Where(x=>x.Id == categoryId).SingleOrDefaultAsync();
            return result;
        }
    }
}
