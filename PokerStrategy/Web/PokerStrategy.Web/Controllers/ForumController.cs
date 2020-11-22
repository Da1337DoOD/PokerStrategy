namespace PokerStrategy.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;

    public class ForumController : Controller
    {
        private readonly IForumCategoryService forumService;
        private readonly IForumThreadService threadService;

        public ForumController(
            IForumCategoryService forumService,
            IForumThreadService threadService)
        {
            this.forumService = forumService;
            this.threadService = threadService;
        }

        public IActionResult Index()
        {
            var allForumCategories = this.forumService
                .GetAll()
                .Select(x => new CategoryListingModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                });

            ForumIndexModel model = new ForumIndexModel
            {
                ForumList = allForumCategories,
            };

            return this.View(model);
        }

        public IActionResult Category(int id)
        {
            var category = this.forumService.GetById(id);

            var threads = this.threadService.GetThreadsByCategory(id);

            var threadListing = threads.Select(t => new ThreadListingModel
            {
                Id = t.Id,
                AuthorId = t.PostedById,
                AuthorPoints = t.PostedBy.Points,
                DateCreated = t.CreatedOn.ToString(),
                RepliesCount = t.Replies.Count(),
                Category = this.BuildCategoryListing(t),
            });

            var model = new CategoryModel
            {
                Category = this.BuildCategoryListing(category),
                Threads = threadListing,
            };

            return this.View(model);
        }

        private CategoryListingModel BuildCategoryListing(ForumCategory category)
        {
            return new CategoryListingModel
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };
        }

        private CategoryListingModel BuildCategoryListing(ForumThread thread)
        {
            var category = thread.Category;
            return this.BuildCategoryListing(category);
        }
    }
}
