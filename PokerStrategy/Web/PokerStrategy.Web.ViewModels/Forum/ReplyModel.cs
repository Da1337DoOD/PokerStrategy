using System;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class ReplyModel
    {
        public int Id { get; set; }

        public string PostedById { get; set; }

        public string PostedByName { get; set; }

        public int PostedByPoints { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public DateTime RepliedOn { get; set; }

        public int ThreadId { get; set; }

        public string Content { get; set; }
    }
}