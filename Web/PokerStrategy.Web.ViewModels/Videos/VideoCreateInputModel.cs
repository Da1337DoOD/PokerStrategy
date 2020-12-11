namespace PokerStrategy.Web.ViewModels.Videos
{
    using System.ComponentModel.DataAnnotations;

    public class VideoCreateInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
