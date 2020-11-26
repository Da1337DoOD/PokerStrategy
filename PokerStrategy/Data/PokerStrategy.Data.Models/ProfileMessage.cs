namespace PokerStrategy.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class ProfileMessage : BaseDeletableModel<int>
    {
        [Required]
        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public string Content { get; set; }
    }
}
