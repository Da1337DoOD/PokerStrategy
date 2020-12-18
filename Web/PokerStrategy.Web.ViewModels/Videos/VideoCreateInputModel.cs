namespace PokerStrategy.Web.ViewModels.Videos
{
    using System.ComponentModel.DataAnnotations;

    public class VideoCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
