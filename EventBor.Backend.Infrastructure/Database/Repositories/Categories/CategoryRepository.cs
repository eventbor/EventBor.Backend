using EventBor.Backend.Domain.Entities;

namespace EventBor.Backend.Infrastructure.Database.Repositories.Categories;

internal class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
