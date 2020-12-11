namespace PokerStrategy.Web.ViewModels.Forum
{
    using System;

    public class ThreadListingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PostedById { get; set; }

        public string PostedByName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CategoryName { get; set; }

        public int RepliesCount { get; set; }
    }
}
