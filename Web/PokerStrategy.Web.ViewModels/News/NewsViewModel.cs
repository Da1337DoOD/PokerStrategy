namespace PokerStrategy.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Text.RegularExpressions;

    using PokerStrategy.Data.Models;
    using PokerStrategy.Services.Mapping;

    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PictureUrl { get; set; }

        public IEnumerable<NewsCommentViewModel> NewsComments { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                return content.Length > 120
                        ? content.Substring(0, 120) + "..."
                        : content;
            }
        }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString =>
            this.CreatedOn.Hour == 0 && this.CreatedOn.Minute == 0
            ? this.CreatedOn.ToString("ddd, dd MMM yyyy", new CultureInfo("bg-BG"))
            : this.CreatedOn.ToString("ddd, dd MMM yyyy HH:mm", new CultureInfo("bg-BG"));

        public int Views { get; set; }
    }
}
