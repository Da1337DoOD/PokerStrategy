using Ganss.XSS;
using System.ComponentModel.DataAnnotations;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class ReplyInputModel
    {
        [MaxLength(5000)]
        [Required]
        public string Content { get; set; }

        public int ThreadId { get; set; }

        [Required]
        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
