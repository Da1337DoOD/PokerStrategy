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
        private readonly IForumCategoryService categoryService;
        private readonly IForumThreadService threadService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumReplyController(
            IForumCategoryService forumService,
            IForumThreadService postService,
            UserManager<ApplicationUser> userManager)
        {
            this.categoryService = forumService;
            this.threadService = postService;
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
                PostedByName = user.UserName,
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
            var userId = this.userManager.GetUserId(this.User);

            var user = await this.userManager.FindByIdAsync(userId);

            var reply = this.BuildReply(model, user);

            await this.threadService.AddReply(reply);

            return this.RedirectToAction("Thread", "ForumThread", new { id = model.ThreadId });
        }

        private ForumReply BuildReply(ReplyModel replyModel, ApplicationUser user)
        {
            var thread = this.threadService.GetById(replyModel.ThreadId);
            var category = this.categoryService.GetById(replyModel.CategoryId);

            return new ForumReply
            {
                Thread = thread,
                Category = category,
                Content = replyModel.Content,
                CreatedOn = DateTime.UtcNow,
                PostedBy = user,
            };
        }
    }
}
