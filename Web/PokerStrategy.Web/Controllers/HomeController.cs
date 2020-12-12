namespace PokerStrategy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Common;
    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels;
    using PokerStrategy.Web.ViewModels.Forum;
    using PokerStrategy.Web.ViewModels.Home;
    using PokerStrategy.Web.ViewModels.News;
    using PokerStrategy.Web.ViewModels.Videos;

    public class HomeController : BaseController
    {
        private readonly IForumThreadService threadService;
        private readonly INewsService newsService;
        private readonly IVideosService videoService;

        public HomeController(
            IForumThreadService threadService, 
            INewsService newsService,
            IVideosService videoService)
        {
            this.threadService = threadService;
            this.newsService = newsService;
            this.videoService = videoService;
        }

        public IActionResult Index()
        {
            var model = this.BuildHomeIndexModel();
            return this.View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestThreads = this.threadService.GetLatestThreads();
            var latestNews = this.newsService.GetLatestNews();
            var latestVideos = this.videoService.GetLatestVideos();

            var threads = latestThreads.Select(t => new ThreadsListingModel
            {
                Id = t.Id,
                Title = t.Title,
                DateCreated = t.CreatedOn,
            });

            var threadList = new List<ThreadsListingModel>();
            if (threads.Any())
            {
                foreach (var thread in threads)
                {
                    if (threadList.Any(existing => existing.Title == thread.Title))
                    {
                        continue;
                    }

                    threadList.Add(thread);

                    if (threadList.Count >= GlobalConstants.LatestPostsAndNewsCount)
                    {
                        break;
                    }
                }
            }

            var news = latestNews.Select(n => new NewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                PictureUrl = n.PictureUrl,
            });
            // VideoListingViewModel
            var videos = latestVideos.Select(v => new VideoViewModel
            {
                Id = v.Id,
                Description = v.Description,
                Title = v.Title,
                Views = v.TimesSeen,
                VideoThumbnailUrl = this.videoService.GetThumbnailLink(v.VideoUrl),
            });

            return new HomeIndexModel
            {
                LatestThreads = threadList,
                LatestNews = news,
                LatestVideos = videos,
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

        public IActionResult GetPrivacy()
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