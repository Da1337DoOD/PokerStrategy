namespace PokerStrategy.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PokerStrategy.Web.ViewModels.Forum;

    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }

        public IEnumerable<ThreadsListingModel> LatestThreads { get; set; }

        public IEnumerable<ThreadsListingModel> LatestReplies { get; set; }
    }
}
