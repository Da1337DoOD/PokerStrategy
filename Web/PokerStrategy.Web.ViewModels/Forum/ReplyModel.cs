namespace PokerStrategy.Web.ViewModels.Forum
{
    using System;

    public class ReplyModel
    {
        public int Id { get; set; }

        public string PostedById { get; set; }

        public string PostedByName { get; set; }

        public int PostedByPoints { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public DateTime RepliedOn { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public int ThreadId { get; set; }

        public string ThreadTitle { get; set; }

        public string Content { get; set; }
    }
}