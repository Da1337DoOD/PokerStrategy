namespace PokerStrategy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;

    public class ForumController : Controller
    {
        private readonly IForumCategoryService categoryService;
        private readonly IForumThreadService threadService;

        public ForumController(
            IForumCategoryService forumService,
            IForumThreadService threadService)
        {
            this.categoryService = forumService;
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

        public IActionResult Category(int id, string searchQuery)
        {
            var category = this.categoryService.GetById(id);

            var threads = this.threadService
                .GetFilteredThreads(category, searchQuery)
                .OrderByDescending(t => t.CreatedOn)
                .ToList();

            var threadListing = threads.Select(t => new ThreadsListingModel
            {
                Id = t.Id,
                Title = t.Title,
                AuthorId = t.PostedById,
                AuthorName = t.PostedBy.UserName,
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

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            // TODO
            return RedirectToAction("Thread", new { id, searchQuery });
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
