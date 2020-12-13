namespace PokerStrategy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class ForumThreadService : IForumThreadService
    {
        private readonly IDeletableEntityRepository<ForumThread> threadRepository;
        private readonly IDeletableEntityRepository<ForumReply> replyRepository;
        private readonly IForumCategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumThreadService(
            IDeletableEntityRepository<ForumThread> threadRepository,
            IDeletableEntityRepository<ForumReply> replyRepository,
            IForumCategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.threadRepository = threadRepository;
            this.replyRepository = replyRepository;
            this.categoryService = categoryService;
        }

        public async Task<ForumThread> CreateNewThread(string userId, int categoryId, string title, string content)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            var thread = new ForumThread
            {
                CategoryId = categoryId,
                Category = this.categoryService.GetById(categoryId),
                Title = title,
                PostedById = user.Id,
                PostedBy = user,
                Content = content,
                CreatedOn = DateTime.UtcNow,
            };

            await this.Add(thread);

            return thread;
        }

        public async Task Add(ForumThread thread)
        {
            await this.threadRepository.AddAsync(thread);

            await this.threadRepository.SaveChangesAsync();

            var reply = new ForumReply
            {
                CreatedOn = thread.CreatedOn,
                Content = thread.Content,
                DeletedOn = thread.DeletedOn,
                IsDeleted = thread.IsDeleted,
                ModifiedOn = thread.ModifiedOn,
                PostedById = thread.PostedById,
                ThreadId = thread.Id,
                PostedBy = thread.PostedBy,
                Thread = thread,
            };

            await this.AddReply(reply);

            await this.replyRepository.SaveChangesAsync();
        }

        public async Task AddReply(ForumReply reply)
        {
            await this.replyRepository.AddAsync(reply);
            await this.replyRepository.SaveChangesAsync();
        }

        public async Task Delete(int threadId)
        {
            var thread = this.threadRepository.All()
                .Where(t => t.Id == threadId)
                .FirstOrDefault();

            this.threadRepository.Delete(thread);

            this.threadRepository.Update(thread);

            await this.threadRepository.SaveChangesAsync();
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

        public IEnumerable<ForumThread> GetThreads(ForumCategory category)
        {
           return category.Threads
                .Where(t => !t.IsDeleted)
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
    }
}
