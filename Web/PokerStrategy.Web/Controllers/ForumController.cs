namespace PokerStrategy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
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
                .Select(x => new CategoriesListingModel
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
            var category = this.categoryService.GetById(id);

            var threads = this.threadService
                .GetThreads(category)
                .Where(t => !t.IsDeleted)
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
                CategoryName = this.BuildCategoryListing(t).Title,
            }).OrderByDescending(t => t.DateCreated);

            var model = new CategoryModel
            {
                Category = this.BuildCategoryListing(category),
                Threads = threadListing,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            // TODO
            return this.RedirectToAction("Thread", new { id, searchQuery });
        }

        private CategoriesListingModel BuildCategoryListing(ForumCategory category)
        {
            return new CategoriesListingModel
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };
        }

        private CategoriesListingModel BuildCategoryListing(ForumThread thread)
        {
            var category = thread.Category;
            return this.BuildCategoryListing(category);
        }
    }
}
