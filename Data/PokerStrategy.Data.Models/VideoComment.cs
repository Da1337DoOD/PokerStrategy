namespace PokerStrategy.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class VideoComment : BaseDeletableModel<int>
    {
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        [Required]
        public string PostedById { get; set; }

        public virtual ApplicationUser PostedBy { get; set; }

        public string Content { get; set; }
    }
}