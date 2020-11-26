namespace PokerStrategy.Data.Models
{
    using System.Collections.Generic;

    using PokerStrategy.Data.Common.Models;

    public class ForumCategory : BaseDeletableModel<int>
    {
        public ForumCategory()
        {
            this.Threads = new HashSet<ForumThread>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<ForumThread> Threads { get; set; }
    }
}
