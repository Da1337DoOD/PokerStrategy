namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly IDeletableEntityRepository<ForumCategory> categoriesRepository;

        public ForumCategoryService(IDeletableEntityRepository<ForumCategory> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<ForumCategory> GetAll()
        {
            return this.categoriesRepository
                .All()
                .OrderBy(x => x.Title)
                .ToList();
        }

        public ForumCategory GetById(int id)
        {
            return this.categoriesRepository.All()
                .Where(c => c.Id == id)
                .Include(c => c.Threads)
                    .ThenInclude(t => t.PostedBy)
                .Include(c => c.Threads)
                    .ThenInclude(t => t.Replies)
                        .ThenInclude(p => p.PostedBy)
                .FirstOrDefault();
        }
    }
}
