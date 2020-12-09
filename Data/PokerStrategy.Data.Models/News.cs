namespace PokerStrategy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        public News()
        {
            this.Comments = new HashSet<NewsComment>();
        }

        [Required]
        public string Title { get; set; }

        public string NewsType { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public string Content { get; set; }

        public int TimeSeen { get; set; }

        public virtual ICollection<NewsComment> Comments { get; set; }
    }
}
