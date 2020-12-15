using Ganss.XSS;
using System.ComponentModel.DataAnnotations;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class ReplyInputModel
    {
        [MaxLength(800)]
        [MinLength(2)]
        [Required]
        public string Content { get; set; }

        public int ThreadId { get; set; }

        public string PostedById { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
