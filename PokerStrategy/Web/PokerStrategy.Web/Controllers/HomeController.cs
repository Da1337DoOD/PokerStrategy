namespace PokerStrategy.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels;
    using PokerStrategy.Web.ViewModels.Forum;
    using PokerStrategy.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IForumThreadService threadService;

        public HomeController(IForumThreadService threadService)
        {
            this.threadService = threadService;
        }

        public IActionResult Index()
        {
            var model = this.BuildHomeIndexModel();
            return this.View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = this.threadService.GetLatestThreads(5);

            var threads = latestPosts.Select(t => new ThreadsListingModel
            {
                Id = t.Id,
                Title = t.Title,
                AuthorId = t.PostedBy.Id,
                AuthorName = t.PostedBy.UserName,
                AuthorPoints = t.PostedBy.Points,
                DateCreated = t.CreatedOn.ToString(),
                RepliesCount = t.Replies.Count(),
                Category = this.GetCategoryListingForThread(t),
            });

            return new HomeIndexModel
            {
                LatestsPosts = threads,
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

        public IActionResult Privacy()
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