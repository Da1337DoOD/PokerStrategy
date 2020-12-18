namespace PokerStrategy.Web.ViewModels.Forum
{
    using Ganss.XSS;
    using System.ComponentModel.DataAnnotations;

    public class ThreadInputModel
    {
        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string Title { get; set; }

        [MaxLength(5000)]
        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
