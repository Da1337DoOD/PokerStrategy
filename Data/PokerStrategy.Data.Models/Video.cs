namespace PokerStrategy.Data.Models
{
    using PokerStrategy.Data.Common.Models;

    public class Video : BaseDeletableModel<int>
    {
        public string Category { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }

        public int TimesSeen { get; set; }
    }
}
