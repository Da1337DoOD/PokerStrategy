namespace PokerStrategy.Web.Controllers
{
    using System;
    using System.Linq;
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
            var currentUser = await this.userManager
                .FindByNameAsync(this.User.Identity.Name);

            var thread = this.threadService.GetById(id);

            var model = new ReplyViewModel
            {
                PostedByName = currentUser.DisplayName,
                PostedByAvatarUrl = currentUser.ImageUrl,
                RepliedOn = DateTime.UtcNow,
                ThreadId = id,
                ThreadTitle = thread.Title,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(ReplyInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.replyService.AddReply(userId, model.ThreadId, model.SanitizedContent);

            return this.RedirectToAction("Thread", "ForumThread", new { id = model.ThreadId });
        }

        [HttpGet]
        public ActionResult EditReplyById(int id)
        {
            var reply = this.replyService.GetById(id);

            var userId = this.userManager.GetUserId(this.User);

            if (!this.replyService.UserIsCreator(userId, id) 
                && !this.User.IsInRole("Admin"))
            {
                 return this.Redirect("https://localhost:44319/Identity/Account/AccessDenied");
            }

            var model = new ReplyViewModel
            {
                Id = reply.Id,
                Content = reply.Content,
                ThreadId = reply.ThreadId,
                ThreadTitle = reply.Thread.Title,
                CurrentUserIsCreator = this.replyService.UserIsCreator(userId, id),
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditReplyById(ReplyViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.replyService.EditAsync(input.Id, input.Content);

            return this.RedirectToAction("Thread", "ForumThread", new { area = "", id = input.ThreadId });
        }
    }
}
