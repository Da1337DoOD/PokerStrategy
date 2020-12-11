namespace PokerStrategy.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    public class NewsCreateInputModel
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
