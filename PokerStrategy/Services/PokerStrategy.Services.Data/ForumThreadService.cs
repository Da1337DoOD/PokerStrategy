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
        private readonly IDeletableEntityRepository<ForumCategory> categoryRepository;
        private readonly IDeletableEntityRepository<ForumReply> replyRepository;

        public ForumThreadService(
            IDeletableEntityRepository<ForumThread> threadRepository,
            IDeletableEntityRepository<ForumCategory> categoryRepository,
            IDeletableEntityRepository<ForumReply> replyRepository)
        {
            this.threadRepository = threadRepository;
            this.categoryRepository = categoryRepository;
            this.replyRepository = replyRepository;
        }

        public async Task Add(ForumThread thread)
        {
           await this.threadRepository.AddAsync(thread);
           await this.threadRepository.SaveChangesAsync();
        }

        public async Task AddReply(ForumReply reply)
        {
            await this.replyRepository.AddAsync(reply);
            await this.replyRepository.SaveChangesAsync();
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
