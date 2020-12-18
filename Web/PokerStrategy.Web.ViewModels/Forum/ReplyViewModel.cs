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

        [MaxLength(50)]
        [MinLength(5)]
        public string ThreadTitle { get; set; }

        [MaxLength(5000)]
        [Required]
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public bool CurrentUserIsCreator { get; set; }
    }
}