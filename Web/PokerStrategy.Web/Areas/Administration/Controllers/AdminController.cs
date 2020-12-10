namespace PokerStrategy.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Common;
    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Forum;
    using PokerStrategy.Web.ViewModels.News;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    [Area("Administration")]
    public class AdminController : Controller
    {
        private readonly INewsService newsService;

        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly IDeletableEntityRepository<ForumThread> threadRepository;
        private readonly IDeletableEntityRepository<ForumReply> replyRepository;
        private readonly IForumReplyService replyService;
        private readonly IForumThreadService threadService;
        private readonly IForumCategoryService categoryService;
        private UserManager<ApplicationUser> userManager;

        public AdminController(
            INewsService newsService,
            IDeletableEntityRepository<News> newsRepository,
            IDeletableEntityRepository<ForumThread> threadRepository,
            IDeletableEntityRepository<ForumReply> replyRepository,
            IForumReplyService replyService,
            IForumThreadService threadService,
            IForumCategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            this.newsService = newsService;
            this.newsRepository = newsRepository;
            this.threadRepository = threadRepository;
            this.replyRepository = replyRepository;
            this.replyService = replyService;
            this.threadService = threadService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> DeleteById(int newsId)
        {
            var news = this.newsRepository.All().Where(x => x.Id == newsId).FirstOrDefault();
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("All", "News", new { area = string.Empty });
        }

        public async Task<IActionResult> DeleteReplyById(int id)
        {
            int threadId = this.replyService.GetById(id).Thread.Id;

            await this.replyService.Delete(id);

            return this.RedirectToAction("Thread", "ForumThread", new { id = threadId, area = string.Empty });
        }

        public async Task<IActionResult> DeleteThreadById(int id)
        {
            int categoryId = this.threadService.GetById(id).CategoryId;

            await this.threadService.Delete(id);

            return this.RedirectToAction("Category", "Forum", new { id = categoryId, area = string.Empty });
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new NewsCreateInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(NewsCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var newsId = await this.newsService.CreateAsync(input.Title, input.Content, input.Url, input.Category);

            return this.RedirectToAction("ById", "News", new { id = newsId, area = string.Empty });
        }

        public async Task<IActionResult> DeleteCommentById(int id)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("All", "News", new { area = string.Empty });
        }

    }
}
