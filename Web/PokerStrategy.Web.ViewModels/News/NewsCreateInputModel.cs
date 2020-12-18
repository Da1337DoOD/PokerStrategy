namespace PokerStrategy.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    public class NewsCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Url { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
