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

        public string Title { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public virtual NewsCategory Category { get; set; }

        public string PictureUrl { get; set; }

        public string Content { get; set; }

        public int TimeSeen { get; set; }

        public virtual ICollection<NewsComment> Comments { get; set; }
    }
}
