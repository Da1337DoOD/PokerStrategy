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
            await this.threadRepository.SaveChangesAsync();

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
            };

            await this.replyRepository.AddAsync(reply);
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

            var threadsByPostDate = this.threadRepository.All()
                .Where(t => !t.Replies.Any())
                .OrderByDescending(t => t.CreatedOn).ToList();

            var result = new List<ForumThread>();

            result.AddRange(threadsByReplyDate);
            result.AddRange(threadsByPostDate);

            return result.OrderByDescending(t => t.CreatedOn).Take(5);
        }

        private DateTime GetLatestReply(ICollection<ForumReply> replies)
        {
            return replies
                .OrderByDescending(r => r.CreatedOn)
                .FirstOrDefault()
                .CreatedOn;
        }

        //public IEnumerable<ForumThread> GetLatestThreads()
        //{
        //    var threads = this.replyRepository.All()
        //        .OrderByDescending(r => r.CreatedOn)
        //        .Select(r => r.Thread);

        //    var uniqueThreads = new List<ForumThread>();

        //    if (threads.Any())
        //    {
        //        foreach (var t in threads)
        //        {
        //            uniqueThreads.Add(t);
        //        }
        //    }

        //    if (uniqueThreads.Count <= 5)
        //    {
        //        return uniqueThreads;
        //    }

        //    return uniqueThreads.Take(5);
        //}

        public IEnumerable<ForumReply> GetLatestReplies()
        {
            var replies = this.replyRepository.All()
                .OrderByDescending(r => r.CreatedOn).Take(5);

            return replies;
        }

        public IEnumerable<ForumThread> GetThreadsByCategory(int id)
        {
            return this.threadRepository.All()
                .Where(x => x.CategoryId == id);
        }
    }

}
