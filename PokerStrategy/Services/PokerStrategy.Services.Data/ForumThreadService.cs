namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class ForumThreadService : IForumThreadService
    {
        private readonly IDeletableEntityRepository<ForumThread> threadRepository;

        public ForumThreadService(
            IDeletableEntityRepository<ForumThread> threadRepository,
            IDeletableEntityRepository<ForumCategory> categoryRepository)
        {
            this.threadRepository = threadRepository;
        }

        public async Task Add(ForumThread thread)
        {
           await this.threadRepository.AddAsync(thread);
           await this.threadRepository.SaveChangesAsync();
        }

        public Task AddReply(ForumReply reply)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public Task Edit(int id, string newContent)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public IEnumerable<ForumThread> GetAll()
        {
            return this.threadRepository.All()
                .Include(t => t.PostedBy)
                .Include(t => t.Replies)
                    .ThenInclude(r => r.PostedBy)
                .Include(p => p.Category);
        }

        public ForumThread GetById(int id)
        {
            return this.threadRepository.All()
                .Where(p => p.Id == id)
                .Include(p => p.PostedBy)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.PostedBy)
                .Include(p => p.Category)
                .FirstOrDefault();
        }

        public IEnumerable<ForumThread> GetFilteredThreads(ForumCategory category, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery)
                ?
                category.Threads
                    .OrderByDescending(t => t.CreatedOn)
                :
                category.Threads
                    .Where(t => t.Title.Contains(searchQuery)
                             || t.Content.Contains(searchQuery))
                    .OrderByDescending(t => t.CreatedOn);
        }

        public IEnumerable<ForumThread> GetLatestThreads(int postsCount)
        {
            return this.GetAll()
                .OrderByDescending(p => p.CreatedOn)
                .Take(postsCount);
        }

        public IEnumerable<ForumThread> GetThreadsByCategory(int id)
        {
            return this.threadRepository.All()
                .Where(x => x.CategoryId == id);
        }
    }
}
