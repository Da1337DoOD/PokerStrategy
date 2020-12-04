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

        public IActionResult ById(int id)
        {
            var dbNews = this.newsService.GetById(id);

            NewsViewModel viewModel = new NewsViewModel
            {
                Content = dbNews.Content,
                CreatedOn = dbNews.CreatedOn,
                NewsComments = dbNews.Comments.Select(c => new NewsCommentViewModel
                {
                    Content = c.Content,
                    CreatedOn = c.CreatedOn,
                    Id = c.Id,
                    NewsId = c.News.Id,
                    UserUserName = c.UserId,
                    ProfilePicture = c.User.ImageUrl,
                }),
                Id = dbNews.Id,
                PictureUrl = dbNews.PictureUrl,
                Title = dbNews.Title,
                Views = dbNews.TimeSeen,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> IncrementViewsById(int id, bool? aftercomment)
        {
            await this.newsService.IncrementViews(id);
            return this.RedirectToAction("ById", new { id = id });
        }

        public IActionResult All(int categoryId)
        {
            var viewModel = new NewsListingViewModel();

            var news = this.newsService.GetAll(categoryId);

            viewModel.News = news.Select(n => new NewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                PictureUrl = n.PictureUrl,
                NewsComments = n.Comments
                    .Select(c => new NewsCommentViewModel
                    {
                        NewsId = c.NewsId,
                        Id = c.Id,
                        CreatedOn = c.CreatedOn,
                        Content = c.Content,
                        ProfilePicture = c.User.ImageUrl,
                        UserUserName = c.User.UserName,
                    }),
                CreatedOn = n.CreatedOn,
                Views = n.TimeSeen,
            });
            return this.View(viewModel);
        }
    }
}
