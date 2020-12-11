namespace PokerStrategy.Web.ViewModels.Forum
{
    using Ganss.XSS;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ThreadModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public string PostedById { get; set; }

        public string PostedByName { get; set; }

        public string PostedByAvatarUrl { get; set; }

        public int UserPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(800)]
        [MinLength(2)]
        [Required]
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public IEnumerable<ReplyModel> Replies { get; set; }
    }
}
