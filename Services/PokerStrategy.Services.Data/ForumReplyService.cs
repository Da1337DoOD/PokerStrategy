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

        //public async Task<int> CreateAsync(string title, string content, string url, string newsType)
        //{
        //    var news = new News
        //    {
        //        Title = title,
        //        Content = content,
        //        PictureUrl = url,
        //        NewsType = newsType,
        //        CreatedOn = DateTime.UtcNow,
        //    };

        //    await this.newsRepository.AddAsync(news);
        //    await this.newsRepository.SaveChangesAsync();

        //    return news.Id;
        //}

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

        //public ForumReply GetLatest(int threadId)
        //{
        //    return this.GetAll().OrderByDescending(r => r.CreatedOn).Where(r => r.ThreadId == threadId).FirstOrDefault();
        //}
    }
}
