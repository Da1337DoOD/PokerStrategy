namespace PokerStrategy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Common;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels;
    using PokerStrategy.Web.ViewModels.Forum;
    using PokerStrategy.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IForumThreadService threadService;
        private readonly IForumReplyService replyService;

        public HomeController(
            IForumThreadService threadService,
            IForumReplyService replyService)
        {
            this.threadService = threadService;
            this.replyService = replyService;
        }

        public IActionResult Index()
        {
            var model = this.BuildHomeIndexModel();
            return this.View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = this.threadService.GetLatestContent();

            var threadList = new List<ThreadsListingModel>();

            var threads = latestPosts.Select(t => new ThreadsListingModel
            {
                Id = t.Id,
                Title = t.Title,
                LatestContent = this.replyService.GetLatest(t.Id).Content,
                DateCreated = t.CreatedOn,
            });

            foreach (var thread in threads)
            {
                if (threadList.Any(existing => existing.Title == thread.Title))
                {
                    continue;
                }

                threadList.Add(thread);

                if (threadList.Count >= GlobalConstants.LatestPostsAndNewsCount)
                {
                    break;
                }
            }

            return new HomeIndexModel
            {
                LatestsPosts = threadList,
                SearchQuery = "",
            };
        }

        private CategoriesListingModel GetCategoryListingForThread(ForumThread t)
        {
            var category = t.Category;

            return new CategoriesListingModel
            {
                Id = category.Id,
                Title = category.Title,
                ImageUrl = category.ImageUrl,
            };
        }

        public IActionResult GetPrivacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}