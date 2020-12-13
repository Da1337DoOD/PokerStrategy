namespace PokerStrategy.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Text.RegularExpressions;

    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortTitle
        {
            get
            {
                var title = WebUtility.HtmlDecode(Regex.Replace(this.Title, @"<[^>]+>", string.Empty));
                title.Replace("\n", string.Empty).Replace("\r", string.Empty);
                return title.Length > 30
                        ? title.Substring(0, 30) + ".."
                        : title;
            }
        }

        public string Content { get; set; }

        public string PictureUrl { get; set; }

        public string ShortContentForAllNews
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                return content.Length > 90
                        ? content.Substring(0, 90) + ".."
                        : content;
            }
        }

        public string ShortContentForLatestNews
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                return content.Length > 330
                        ? content.Substring(0, 330) + ".."
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
