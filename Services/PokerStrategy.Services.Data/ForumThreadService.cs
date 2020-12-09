namespace PokerStrategy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class ForumThreadService : IForumThreadService
    {
        private readonly IDeletableEntityRepository<ForumThread> threadRepository;
        private readonly IDeletableEntityRepository<ForumReply> replyRepository;

        public ForumThreadService(
            IDeletableEntityRepository<ForumThread> threadRepository,
            IDeletableEntityRepository<ForumReply> replyRepository)
        {
            this.threadRepository = threadRepository;
            this.replyRepository = replyRepository;
        }

        public async Task Add(ForumThread thread)
        {
            await this.threadRepository.AddAsync(thread);

            var reply = new ForumReply
            {
                CategoryId = thread.CategoryId,
                CreatedOn = thread.CreatedOn,
                Content = thread.Content,
                DeletedOn = thread.DeletedOn,
                IsDeleted = thread.IsDeleted,
                ModifiedOn = thread.ModifiedOn,
                PostedById = thread.PostedById,
                ThreadId = thread.Id,
                Category = thread.Category,
                PostedBy = thread.PostedBy,
                Thread = thread,
            };

            await this.AddReply(reply);
            await this.threadRepository.SaveChangesAsync();
            await this.replyRepository.SaveChangesAsync();
            await this.threadRepository.SaveChangesAsync();
            await this.replyRepository.SaveChangesAsync();
        }

        public async Task AddReply(ForumReply reply)
        {
            await this.replyRepository.AddAsync(reply);
            await this.replyRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var thread = this.threadRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.threadRepository.Delete(thread);

            this.threadRepository.Update(thread);

            await this.threadRepository.SaveChangesAsync();
        }

        public async Task Edit(int id, string newTitle, string newContent)
        {
            var thread = this.threadRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            thread.Title = newTitle;
            thread.Content = newContent;

            this.threadRepository.Update(thread);

            await this.threadRepository.SaveChangesAsync();
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
                .Where(t => t.Id == id)
                .Include(t => t.PostedBy)
                .Include(t => t.Replies)
                    .ThenInclude(r => r.PostedBy)
                .Include(t => t.Category)
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

        public IEnumerable<ForumThread> GetLatestThreads()
        {
            var threadsByReplyDate = this.replyRepository.All()
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => r.Thread).ToList();

            var result = new List<ForumThread>();

            foreach (var thread in threadsByReplyDate)
            {
                if (!result.Contains(thread))
                {
                    result.Add(thread);
                }
            }

            if (result.Count <= 5)
            {
                return result;
            }

            return result.Take(5);
        }

        public IEnumerable<ForumThread> GetThreadsByCategory(int id)
        {
            return this.threadRepository.All()
                .Where(x => x.CategoryId == id);
        }
    }

}
