﻿namespace PokerStrategy.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Common;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.News;
    using PokerStrategy.Web.ViewModels.Videos;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    [Area("Administration")]
    public class AdminController : Controller
    {
        private readonly INewsService newsService;

        private readonly IForumReplyService replyService;
        private readonly IForumThreadService threadService;

        private readonly IVideosService videosService;

        public AdminController(
            INewsService newsService,
            IForumReplyService replyService,
            IForumThreadService threadService,
            IVideosService videosService)
        {
            this.newsService = newsService;
            this.replyService = replyService;
            this.threadService = threadService;
            this.videosService = videosService;
        }

        public async Task<IActionResult> DeleteNewsById(int id)
        {
            await this.newsService.Delete(id);

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

        public async Task<IActionResult> DeleteVideoById(int id)
        {
            await this.videosService.Delete(id);

            return this.RedirectToAction("All", "Video", new { area = string.Empty });
        }

        [HttpGet]
        public ViewResult EditNewsById(int id)
        {
            var news = this.newsService.GetById(id);
            var model = new NewsViewModel
            {
                Id = news.Id,
                Content = news.Content,
                Title = news.Title,
                PictureUrl = news.PictureUrl,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditNewsById(NewsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.newsService.EditAsync(input.Id, input.Title, input.Content, input.PictureUrl);

            return this.RedirectToAction("News", "News", new { area="", input.Id });
        }

        [HttpGet]
        public ViewResult EditVideoById(int id)
        {
            var news = this.videosService.GetById(id);
            var model = new VideoViewModel
            {
                Id = news.Id,
                Description = news.Description,
                Title = news.Title,
                VideoUrl = news.VideoUrl,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditVideoById(VideoViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.videosService.EditAsync(input.Id, input.Title, input.Description, input.VideoUrl);

            return this.RedirectToAction("Video", "Video", new { area = "", input.Id });
        }

        [Authorize]
        public IActionResult CreateNews()
        {
            var viewModel = new NewsCreateInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNews(NewsCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var newsId = await this.newsService.CreateAsync(input.Title, input.Content, input.Url, input.Category);

            return this.RedirectToAction("News", "News", new { id = newsId, area = string.Empty });
        }

        [Authorize]
        public IActionResult CreateVideo()
        {
            var viewModel = new VideoCreateInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVideo(VideoCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var videoId = await this.videosService.CreateAsync(input.Title, input.Description, input.VideoUrl, input.Category);

            return this.RedirectToAction("Video", "Video", new { id = videoId, area = string.Empty });
        }
    }
}
