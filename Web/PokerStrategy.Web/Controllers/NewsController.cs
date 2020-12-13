namespace PokerStrategy.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Web.ViewModels.News;

    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult News(int id)
        {
            var dbNews = this.newsService.GetById(id);

            NewsViewModel viewModel = new NewsViewModel
            {
                Content = dbNews.Content,
                CreatedOn = dbNews.CreatedOn,
                Id = dbNews.Id,
                PictureUrl = dbNews.PictureUrl,
                Title = dbNews.Title,
                Views = dbNews.TimesSeen,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> IncrementViewsById(int id, bool? aftercomment)
        {
            await this.newsService.IncrementViews(id);
            return this.RedirectToAction("News", new { id = id });
        }

        public IActionResult All()
        {
            var viewModel = new NewsListingViewModel();

            var news = this.newsService.GetAll();

            viewModel.News = news.Select(n => new NewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                PictureUrl = n.PictureUrl,
                CreatedOn = n.CreatedOn,
                Views = n.TimesSeen,
            });
            return this.View(viewModel);
        }
    }
}
