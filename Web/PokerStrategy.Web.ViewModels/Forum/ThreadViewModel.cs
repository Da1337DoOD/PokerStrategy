namespace PokerStrategy.Web.ViewModels.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Ganss.XSS;

    public class ThreadViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string Title { get; set; }

        public string PostedByName { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(800)]
        [MinLength(2)]
        [Required]
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public IEnumerable<ReplyViewModel> Replies { get; set; }

        public string GetReplyJumpPosition() => this.Replies.Any() ?
            ("#" + this.Replies.LastOrDefault().Id.ToString())
            :
            "#top";
    }
}
