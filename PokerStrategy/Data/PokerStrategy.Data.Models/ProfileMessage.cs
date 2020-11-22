namespace PokerStrategy.Data.Models
{
    using PokerStrategy.Data.Common.Models;

    public class ProfileMessage : BaseDeletableModel<int>
    {
        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public string Content { get; set; }
    }
}
