namespace PokerStrategy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PokerStrategy.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        public string NewsType { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public string Content { get; set; }

        public int TimesSeen { get; set; }
    }
}
