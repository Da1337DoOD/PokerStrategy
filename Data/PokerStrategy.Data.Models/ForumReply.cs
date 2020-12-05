namespace PokerStrategy.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class ForumReply : BaseDeletableModel<int>
    {
        public int CategoryId { get; set; }

        public virtual ForumCategory Category { get; set; }

        public int ThreadId { get; set; }

        public virtual ForumThread Thread { get; set; }

        [Required]
        public string PostedById { get; set; }

        public virtual ApplicationUser PostedBy { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
