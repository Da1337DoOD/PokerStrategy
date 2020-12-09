namespace PokerStrategy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class Video : BaseDeletableModel<int>
    {
        public Video()
        {
            this.VideoComments = new HashSet<VideoComment>();
        }

        public string Category { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public ICollection<VideoComment> VideoComments { get; set; }
    }
}
