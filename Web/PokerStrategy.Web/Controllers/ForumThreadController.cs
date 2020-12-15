namespace PokerStrategy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;

    public class ForumThreadController : Controller
    {
        private readonly IForumThreadService threadService;
        private readonly IForumCategoryService categoryService;
        private readonly IForumReplyService replyService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumThreadController(
            IForumThreadService threadService,
            IForumCategoryService categoryService,
            IForumReplyService replyService,
            UserManager<ApplicationUser> userManager)
        {
            this.threadService = threadService;
            this.categoryService = categoryService;
            this.replyService = replyService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var category = this.categoryService.GetById(id);

            var model = new ThreadInputModel
            {
                CategoryId = category.Id,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddThread(ThreadInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            var thread = await this.threadService.CreateNewThread(userId, model.CategoryId, model.Title, model.SanitizedContent);

            return this.RedirectToAction("Thread", "ForumThread", new { id = thread.Id });
        }

        public IActionResult Thread(int id)
        {
            var thread = this.threadService.GetById(id);

            //var category = this.categoryService.GetById(thread.CategoryId);

            var currentUserId = this.userManager.GetUserId(this.User);

            var replies = thread.Replies.Select(r => new ReplyViewModel
            {
                Id = r.Id,
                PostedByName = r.PostedBy.DisplayName,
                PostedByAvatarUrl = r.PostedBy.ImageUrl,
                RepliedOn = r.CreatedOn,
                Content = r.Content,
                ThreadId = r.ThreadId,
                CurrentUserIsCreator = this.replyService.UserIsCreator(currentUserId, r.Id),
            });

            var model = new ThreadViewModel
            {
                Id = thread.Id,
                Title = thread.Title,
                PostedByName = thread.PostedBy.UserName,
                PostedByAvatarUrl = thread.PostedBy.ImageUrl,
                CreatedOn = thread.CreatedOn,
                Content = thread.Content,
                Replies = replies.OrderByDescending(r => r.RepliedOn),
            };

            return this.View(model);
        }
    }
}
