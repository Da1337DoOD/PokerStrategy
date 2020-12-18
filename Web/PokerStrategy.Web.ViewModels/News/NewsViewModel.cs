namespace PokerStrategy.Web.ViewModels.News
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Net;
    using System.Text.RegularExpressions;

    public class NewsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        public string Title { get; set; }

        public string ShortTitle
        {
            get
            {
                if (Title != null)
                {
                    var content = WebUtility.HtmlDecode(Regex.Replace(this.Title, @"<[^>]+>", string.Empty));
                    content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                    return content.Length > 50
                            ? content.Substring(0, 50) + ".."
                            : content;
                }
                return "";
            }
        }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        public string ShortContentForAllNews
        {
            get
            {
                if (Content != null)
                {
                    var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                    content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                    return content.Length > 80
                            ? content.Substring(0, 80) + ".."
                            : content;
                }
                return "";
            }
        }

        [Required]
        public string PictureUrl { get; set; }

        public string ShortContentForLatestNews
        {
            get
            {
                if (Content != null)
                {
                    var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                    content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                    return content.Length > 330
                            ? content.Substring(0, 330) + ".."
                            : content;
                }
                return "";
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
