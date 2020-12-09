namespace PokerStrategy.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using PokerStrategy.Web.ViewModels.Forum;

    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }

        public IEnumerable<ThreadsListingModel> LatestThreads { get; set; }
    }
}
