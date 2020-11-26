namespace PokerStrategy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class ForumThread : BaseDeletableModel<int>
    {
        public ForumThread()
        {
            this.Replies = new HashSet<ForumReply>();
        }

        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

        public string Title { get; set; }

        [Required]
        public string PostedById { get; set; }

        public virtual ApplicationUser PostedBy { get; set; }

        public string Content { get; set; }

        public virtual ICollection<ForumReply> Replies { get; set; }

        public int TimesSeen { get; set; }
    }
}
