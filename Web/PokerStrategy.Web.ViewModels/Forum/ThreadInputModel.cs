namespace PokerStrategy.Web.ViewModels.Forum
{
    using Ganss.XSS;
    using System.ComponentModel.DataAnnotations;

    public class ThreadInputModel
    {
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string InputContent { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content => new HtmlSanitizer().Sanitize(this.InputContent);
    }
}
