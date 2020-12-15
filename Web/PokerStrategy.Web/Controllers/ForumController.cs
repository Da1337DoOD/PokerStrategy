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
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                });

            CategoriesListingViewModel model = new CategoriesListingViewModel
            {
                CategoriesList = allForumCategories,
            };

            return this.View(model);
        }

        public IActionResult Category(int id)
        {
            var category = this.categoryService.GetById(id);

            var categoryListing = new CategoryViewModel
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
            };

            var threads = this.threadService
                .GetThreads(category)
                .OrderByDescending(t => t.CreatedOn)
                .ToList();

            var threadListing = threads.Select(t => new ThreadViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Content = t.Content,
                CreatedOn = t.CreatedOn,
                PostedByAvatarUrl = t.PostedBy.ImageUrl,
                PostedByName = t.PostedBy.DisplayName,
            })
            .OrderByDescending(t => t.CreatedOn);

            var model = new ThreadListingViewModel
            {
                Category = categoryListing,
                ThreadsList = threadListing,
            };

            return this.View(model);
        }
    }
}
