using ClassLibrary.Data;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories
{
     public class DietaryTagRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DietaryTagRepository(
            ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        private IQueryable<DietaryTag> Base()
        {
            return _dbContext.Set<DietaryTag>()
                .AsNoTracking()
                .AsQueryable();
        }

        public IQueryable<DietaryTag> GetAsQueryable()
        {
            return Base();
        }

        public async Task<DietaryTag?> GetById(Guid id)
        {
            try
            {
                return await Base().FirstOrDefaultAsync(x => x.ID.Equals(id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    }
