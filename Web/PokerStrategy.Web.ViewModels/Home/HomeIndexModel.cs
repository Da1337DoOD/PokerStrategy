namespace PokerStrategy.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using PokerStrategy.Web.ViewModels.Forum;
    using PokerStrategy.Web.ViewModels.News;

    public class HomeIndexModel
    {
        public IEnumerable<ThreadsListingModel> LatestThreads { get; set; }

        public IEnumerable<NewsViewModel> LatestNews { get; set; }

        public IEnumerable<ThreadsListingModel> LatestVideos { get; set; } // TODO
    }
}
