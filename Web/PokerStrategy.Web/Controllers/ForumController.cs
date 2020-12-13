namespace PokerStrategy.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;

    public class ForumController : Controller
    {
        private readonly IForumCategoryService categoryService;
        private readonly IForumThreadService threadService;

        public ForumController(
            IForumCategoryService categoryService,
            IForumThreadService threadService)
        {
            this.categoryService = categoryService;
            this.threadService = threadService;
        }

        public IActionResult Index()
        {
            var allForumCategories = this.categoryService
                .GetAll()
                .Select(c => new CategoriesListingModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                });

            ForumIndexModel model = new ForumIndexModel
            {
                ForumList = allForumCategories,
            };

            return this.View(model);
        }

        public IActionResult Category(int id)
        {
            var category = this.categoryService.GetById(id);

            var categoryListing = new CategoriesListingModel
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };

            var threads = this.threadService
                .GetThreads(category)
                .OrderByDescending(t => t.CreatedOn)
                .ToList();

            var threadListing = threads.Select(t => new ThreadsListingModel
            {
                Id = t.Id,
                Title = t.Title,
                AuthorId = t.PostedById,
                AuthorName = t.PostedBy.DisplayName,
                AuthorPoints = t.PostedBy.Points,
                DateCreated = t.CreatedOn,
                RepliesCount = t.Replies.Count(),
                CategoryName = t.Category.Title,
            }).OrderByDescending(t => t.DateCreated);

            var model = new CategoryModel
            {
                Category = categoryListing,
                Threads = threadListing,
            };

            return this.View(model);
        }
    }
}
