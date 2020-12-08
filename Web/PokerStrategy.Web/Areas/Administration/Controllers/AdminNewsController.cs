namespace CyberSecurityBG.Web.Areas.Administration.Controllers
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
    using PokerStrategy.Web.ViewModels.News;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    [Area("Administration")]
    public class AdminNewsController : Controller
    {
        private readonly INewsService newsService;

        private readonly IDeletableEntityRepository<News> newsRepository;

        private UserManager<ApplicationUser> userManager;

        public AdminNewsController(
            INewsService newsService,
            IDeletableEntityRepository<News> newsRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.newsService = newsService;
            this.newsRepository = newsRepository;
            this.userManager = userManager;
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("All", "News", new { area = string.Empty });
        }

        public IActionResult GetEditById(int id)
        {
            var viewData = this.newsService.GetById(id);
            return this.View(viewData);
        }

        public async Task<IActionResult> EditById(int id, string url, string title, string content)
        {
            var news = this.newsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            news.Title = title;
            news.Content = content;
            news.PictureUrl = url;
            await this.newsRepository.SaveChangesAsync();
            return this.RedirectToAction("ById", "News", new { id = news.Id, area = string.Empty });
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
