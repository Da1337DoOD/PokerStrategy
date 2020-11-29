namespace PokerStrategy.Web.ViewModels.Forum
{
    using System;
    using System.Collections.Generic;

    public class ThreadModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public string PostedById { get; set; }

        public string PostedByName { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public int UserPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public IEnumerable<ReplyModel> Replies { get; set; }
    }
}
