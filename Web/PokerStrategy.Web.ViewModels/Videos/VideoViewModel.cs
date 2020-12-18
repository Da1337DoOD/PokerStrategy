namespace PokerStrategy.Web.ViewModels.Videos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Text.RegularExpressions;

    public class VideoViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string ShortenedTitle
        {
            get
            {
                if (Title != null)
                {
                    var content = WebUtility.HtmlDecode(Regex.Replace(this.Title, @"<[^>]+>", string.Empty));
                    content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                    return content.Length > 40
                            ? content.Substring(0, 40) + ".."
                            : content;
                }
                return "";
            }
        }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        public string ShortenedDescription
        {
            get
            {
                if (Description != null)
                {
                    var content = WebUtility.HtmlDecode(Regex.Replace(this.Description, @"<[^>]+>", string.Empty));
                    content.Replace("\n", string.Empty).Replace("\r", string.Empty);
                    return content.Length > 80
                            ? content.Substring(0, 80) + ".."
                            : content;
                }
                return "";
            }
        }

        [Required]
        public string VideoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Views { get; set; }

        public string VideoThumbnailUrl { get; set; }
    }
}
