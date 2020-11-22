namespace PokerStrategy.Data.Models
{
    using System.Collections.Generic;

    using PokerStrategy.Data.Common.Models;

    public class NewsCategory : BaseDeletableModel<int>
    {
        public NewsCategory()
        {
            this.News = new HashSet<News>();
        }

        public string Title { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
