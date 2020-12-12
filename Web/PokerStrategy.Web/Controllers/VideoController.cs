namespace PokerStrategy.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PokerStrategy.Services.Data;
    using PokerStrategy.Web.ViewModels.Videos;

    public class VideoController : Controller
    {
        private IVideosService videoService;

        public VideoController(IVideosService videoService)
        {
            this.videoService = videoService;
        }

        public IActionResult ById(int id)
        {
            var video = this.videoService.GetById(id);

            VideoViewModel viewModel = new VideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                CreatedOn = video.CreatedOn,
                VideoUrl = this.videoService.GetEmbededVideoLink(video.VideoUrl),
                Views = video.TimesSeen,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> IncrementViewsById(int id, bool? aftercomment)
        {
            await this.videoService.IncrementViews(id);
            return this.RedirectToAction("ById", new { id = id });
        }

        public IActionResult All()
        {
            var viewModel = new VideoListingViewModel();

            var videos = this.videoService.GetAll();

            viewModel.Videos = videos.Select(v => new VideoViewModel
            {
                VideoUrl = v.VideoUrl,
                Description = v.Description,
                CreatedOn = v.CreatedOn,
                Id = v.Id,
                Title = v.Title,
                Views = v.TimesSeen,
                VideoThumbnailUrl = this.videoService.GetThumbnailLink(v.VideoUrl),
            });

            return this.View(viewModel);
        }
    }
}
