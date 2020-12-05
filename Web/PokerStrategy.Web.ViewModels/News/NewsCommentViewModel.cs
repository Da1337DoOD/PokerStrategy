namespace PokerStrategy.Web.ViewModels.News
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class NewsCommentViewModel
    {
        public int NewsId { get; set; }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string Content { get; set; }

        public string ProfilePicture { get; set; }

   //     public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public string CreatedOnAsString =>
                this.CreatedOn.Hour == 0 && this.CreatedOn.Minute == 0
                ? this.CreatedOn.ToString("ddd, dd MMM yyyy", new CultureInfo("bg-BG"))
                : this.CreatedOn.ToString("ddd, dd MMM yyyy HH:mm", new CultureInfo("bg-BG"));
    }
}
