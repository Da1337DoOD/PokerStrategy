namespace PokerStrategy.Web.ViewModels.Forum
{
    using Ganss.XSS;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReplyViewModel
    {
        public int Id { get; set; }

        public string PostedByName { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public DateTime RepliedOn { get; set; }

        public int ThreadId { get; set; }

        public string ThreadTitle { get; set; }

        [Required]
        [MaxLength(5000)]
        public string InputContent { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content => new HtmlSanitizer().Sanitize(this.InputContent);

        public bool CurrentUserIsCreator { get; set; }
    }
}