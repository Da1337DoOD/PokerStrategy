using Ganss.XSS;
using System.ComponentModel.DataAnnotations;

namespace PokerStrategy.Web.ViewModels.Forum
{
    public class ReplyInputModel
    {
        [Required]
        [MaxLength(5000)]
        public string InputContent { get; set; }

        public int ThreadId { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content => new HtmlSanitizer().Sanitize(this.InputContent);
    }
}
