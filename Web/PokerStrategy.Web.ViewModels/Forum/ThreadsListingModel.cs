using System;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class ThreadsListingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public int AuthorPoints { get; set; }

        public DateTime DateCreated { get; set; }

        public CategoriesListingModel Category { get; set; }

        public int RepliesCount { get; set; }

        public string LatestTitle { get; set; }

        public string LatestContent { get; set; }

        public int LatestThreadId { get; set; }
    }
}
