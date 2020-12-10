namespace PokerStrategy.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;

    public class NewsReplyController : Controller
    {
       // private readonly INewsReplyService replyService;
        private readonly INewsService newsService;
        private readonly UserManager<ApplicationUser> userManager;

        public NewsReplyController(
          //  INewsReplyService replyService,
            INewsService newsService,
            UserManager<ApplicationUser> userManager
            )
        {
        //    this.replyService = replyService;
            this.newsService = newsService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            var user = await this.userManager
                .FindByNameAsync(this.User.Identity.Name);

            var news = this.newsService.GetById(id);

            var model = new ReplyModel
            {
                PostedById = user.Id,
                PostedByName = user.UserName,
                PostedByPoints = user.Points,
                PostedByAvatarUrl = user.ImageUrl,

                RepliedOn = DateTime.UtcNow,

                // news id, title and type
                ThreadId = id,
                ThreadTitle = news.Title,
                CategoryTitle = news.NewsType,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(ReplyModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            var user = await this.userManager.FindByIdAsync(userId);

            var reply = this.BuildReply(model, user);

            await this.newsService.AddReply(reply);

            return this.RedirectToAction("ById", "News", new { id = model.ThreadId });
        }

        private NewsComment BuildReply(ReplyModel replyModel, ApplicationUser user)
        {
            var news = this.newsService.GetById(replyModel.ThreadId);

            return new NewsComment
            {
                News = news,
                Content = replyModel.Content,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,
                NewsId = news.Id,
            };
        }
    }
}
