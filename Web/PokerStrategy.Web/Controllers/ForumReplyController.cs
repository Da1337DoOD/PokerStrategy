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

    public class ForumReplyController : Controller
    {
        private readonly IForumThreadService threadService;
        private readonly IForumReplyService replyService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumReplyController(
            IForumThreadService threadService,
            IForumReplyService replyService,
            UserManager<ApplicationUser> userManager)
        {
            this.threadService = threadService;
            this.replyService = replyService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            var user = await this.userManager
                .FindByNameAsync(this.User.Identity.Name);

            var thread = this.threadService.GetById(id);

            var model = new ReplyModel
            {
                PostedById = user.Id,
                PostedByName = user.DisplayName,
                PostedByPoints = user.Points,
                PostedByAvatarUrl = user.ImageUrl,
                RepliedOn = DateTime.UtcNow,
                ThreadId = id,
                ThreadTitle = thread.Title,
                CategoryId = thread.Category.Id,
                CategoryTitle = thread.Category.Title,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(ReplyModel model)
        {
            await this.replyService.AddReply(model.PostedById, model.ThreadId, model.SanitizedContent);

            return this.RedirectToAction("Thread", "ForumThread", new { id = model.ThreadId });
        }
    }
}
