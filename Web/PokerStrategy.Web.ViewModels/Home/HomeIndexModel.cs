namespace PokerStrategy.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using PokerStrategy.Web.ViewModels.Forum;
    using PokerStrategy.Web.ViewModels.News;
    using PokerStrategy.Web.ViewModels.Videos;

    public class HomeIndexModel
    {
        public IEnumerable<ThreadViewModel> LatestThreads { get; set; }

        public IEnumerable<NewsViewModel> LatestNews { get; set; }

        public IEnumerable<VideoViewModel> LatestVideos { get; set; }
    }
}
