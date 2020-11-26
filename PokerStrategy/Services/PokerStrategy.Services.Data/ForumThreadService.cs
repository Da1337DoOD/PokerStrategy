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

        public ForumThreadService(IDeletableEntityRepository<ForumThread> threadRepository)
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
            // TODO
            throw new System.NotImplementedException();
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

        public IEnumerable<ForumThread> GetFilteredThreads(string searchQuery)
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public IEnumerable<ForumThread> GetThreadsByCategory(int id)
        {
            return this.threadRepository.All()
                .Where(x => x.CategoryId == id);
        }
    }
}
