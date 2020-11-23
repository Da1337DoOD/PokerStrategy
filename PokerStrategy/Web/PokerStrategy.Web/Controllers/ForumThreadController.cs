namespace PokerStrategy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;

    public class ForumThreadController : Controller
    {
        private readonly IForumThreadService threadService;

        public ForumThreadController(IForumThreadService threadService)
        {
            this.threadService = threadService;
        }

        public IActionResult Index(int id)
        {
            var thread = this.threadService.GetById(id);

            var replies = this.BuildThreadReplies(thread.Replies);

            var model = new ThreadModel
            {
                Id = thread.Id,
                Title = thread.Title,
                PostedById = thread.PostedById,
                PostedByName = thread.PostedBy.UserName,
                PostedByAvatarUrl = thread.PostedBy.ImageUrl,
                UserPoints = thread.PostedBy.Points,
                CreatedOn = thread.CreatedOn,
                Content = thread.Content,
                Replies = replies,
            };

            return this.View(model);
        }

        private IEnumerable<ReplyModel> BuildThreadReplies(ICollection<ForumReply> replies)
        {
            return replies.Select(r => new ReplyModel
            {
                Id = r.Id,
                PostedById = r.PostedById,
                PostedByName = r.PostedBy.UserName,
                PostedByAvatarUrl = r.PostedBy.ImageUrl,
                PostedByPoints = r.PostedBy.Points,
                RepliedOn = r.CreatedOn,
                Content = r.Content,
            });
        }
    }
}
