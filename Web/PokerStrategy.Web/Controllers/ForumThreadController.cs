namespace PokerStrategy.Web.Controllers
{
    using System;
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

        private readonly UserManager<ApplicationUser> userManager;

        public ForumThreadController(
            IForumThreadService threadService,
            IForumCategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            this.threadService = threadService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var category = this.categoryService.GetById(id);

            var currentUser = this.User.Identity;

            var model = new NewThreadModel
            {
                CategoryName = category.Title,
                CategoryId = category.Id,
                CategoryImageUrl = category.ImageUrl,
                AuthorName = currentUser.Name,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddThread(NewThreadModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            var user = await this.userManager.FindByIdAsync(userId);

            var thread = this.BuildThread(model, user);

            await this.threadService.Add(thread);

            return this.RedirectToAction("Thread", "ForumThread", new { id = thread.Id });
        }

        public IActionResult Thread(int id)
        {
            var thread = this.threadService.GetById(id);

            var category = this.categoryService.GetById(thread.CategoryId);

            var replies = this.BuildThreadReplies(thread.Replies);

            var model = new ThreadModel
            {
                Id = thread.Id,
                Title = thread.Title,
                CategoryId = thread.CategoryId,
                CategoryTitle = category.Title,
                PostedById = thread.PostedById,
                PostedByName = thread.PostedBy.UserName,
                PostedByAvatarUrl = thread.PostedBy.ImageUrl,
                UserPoints = thread.PostedBy.Points,
                CreatedOn = thread.CreatedOn,
                Content = thread.Content,
                Replies = replies.OrderByDescending(r => r.RepliedOn),
            };

            return this.View(model);
        }

        private ForumThread BuildThread(NewThreadModel model, ApplicationUser user)
        {
            var category = this.categoryService.GetById(model.CategoryId);

            return new ForumThread
            {
                CategoryId = category.Id,
                Category = category,
                Title = model.Title,
                PostedById = user.Id,
                PostedBy = user,
                Content = model.SanitizedContent,
                CreatedOn = DateTime.UtcNow,
            };
        }

        private IEnumerable<ReplyModel> BuildThreadReplies(ICollection<ForumReply> replies)
        {
            return replies.Select(r => new ReplyModel
            {
                Id = r.Id,
                PostedById = r.PostedById,
                PostedByName = r.PostedBy.DisplayName,
                PostedByAvatarUrl = r.PostedBy.ImageUrl,
                PostedByPoints = r.PostedBy.Points,
                RepliedOn = r.CreatedOn,
                Content = r.Content,
            });
        }
    }
}
