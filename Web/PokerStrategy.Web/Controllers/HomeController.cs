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

            var threads = latestThreads.Select(t => new ThreadViewModel
            {
                Id = t.Id,
                Title = t.Title,
                CreatedOn = t.CreatedOn,
            });

            var threadList = new List<ThreadViewModel>();
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
    }
}