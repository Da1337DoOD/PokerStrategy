using System;
using System.Collections.Generic;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class ThreadModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PostedById { get; set; }

        public string PostedByName { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public int UserPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public IEnumerable<ReplyModel> Replies { get; set; }
    }
}
