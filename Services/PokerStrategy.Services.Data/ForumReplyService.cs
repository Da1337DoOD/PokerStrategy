namespace PokerStrategy.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class ForumReplyService : IForumReplyService
    {
        private readonly IDeletableEntityRepository<ForumReply> replyRepository;
        private readonly IForumThreadService threadService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumReplyService(
            IDeletableEntityRepository<ForumReply> replyRepository,
            IForumThreadService threadService,
            UserManager<ApplicationUser> userManager)
        {
            this.replyRepository = replyRepository;
            this.threadService = threadService;
            this.userManager = userManager;
        }

        public async Task Delete(int id)
        {
            var reply = this.GetById(id);
            this.replyRepository.Delete(reply);

            this.replyRepository.Update(reply);

            await this.replyRepository.SaveChangesAsync();
        }

        public ForumReply GetById(int id)
        {
            return this.replyRepository.All()
                .Include(r => r.Thread)
                    .ThenInclude(t => t.Category)
                .Include(r => r.Thread)
                    .ThenInclude(t => t.PostedBy)
                .First(r => r.Id == id); // First on top?
        }

        public async Task AddReply(string userId, int threadId, string content)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            var thread = this.threadService.GetById(threadId);

            var reply = new ForumReply
            {
                Thread = thread,
                Content = content,
                CreatedOn = DateTime.UtcNow,
                PostedBy = user,
            };

            await this.threadService.AddReply(reply);
        }

        public async Task EditAsync(int replyId, string newContent)
        {
            var reply = this.GetById(replyId);
            reply.Content = newContent;

            this.replyRepository.Update(reply);
            await this.replyRepository.SaveChangesAsync();

            return;
        }

        public bool UserIsCreator(string userId, int replyId)
        {
            var reply = this.replyRepository.All().First(r => r.Id == replyId);

            return reply.PostedById == userId;
        }
    }
}
