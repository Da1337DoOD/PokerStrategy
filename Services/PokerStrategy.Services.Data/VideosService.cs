﻿namespace PokerStrategy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Common.Repositories;
    using PokerStrategy.Data.Models;

    public class VideosService : IVideosService
    {
        private readonly IDeletableEntityRepository<Video> videoRepository;

        public VideosService(IDeletableEntityRepository<Video> videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async Task<int> CreateAsync(string title, string desc, string url, string category)
        {
            var video = new Video
            {
                Title = title,
                Description = desc,
                VideoUrl = url,
                Category = category,
                CreatedOn = DateTime.UtcNow,
            };

            await this.videoRepository.AddAsync(video);
            await this.videoRepository.SaveChangesAsync();

            return video.Id;
        }

        public async Task Delete(int id)
        {
            var video = this.videoRepository.All()
                       .Where(v => v.Id == id)
                       .FirstOrDefault();

            this.videoRepository.Delete(video);

            this.videoRepository.Update(video);

            await this.videoRepository.SaveChangesAsync();
        }

        public IEnumerable<Video> GetAll()
        {
            IQueryable<Video> video = this.videoRepository.All()
                .OrderByDescending(v => v.CreatedOn);

            return video.ToList();
        }

        public Video GetById(int id)
        {
            var video = this.videoRepository.All()
                .Where(v => v.Id == id)
                .FirstOrDefault();

            return video;
        }

        public IEnumerable<Video> GetLatestVideos()
        {
            var videosByDate = this.videoRepository.All()
                    .OrderByDescending(v => v.CreatedOn).ToList();

            if (videosByDate.Count <= 5)
            {
                return videosByDate;
            }

            return videosByDate.Take(5);
        }

        public string GetThumbnailLink(string videoUrl)
        {
            if (string.IsNullOrEmpty(videoUrl))
            {
                return "https://i.ytimg.com/vi/1/0.jpg";
            }

            string startLink = "https://i.ytimg.com/vi/";
            string midLink1 = videoUrl.Replace("https://www.youtube.com/watch?v=", "");
            midLink1 = midLink1.Replace("https://youtu.be/", "");
            string midLink2 = "";
            foreach(var ch in midLink1)
            {
                if (ch == '&') break;
                midLink2 += ch;
            }
            string endLink = "/0.jpg";
            string thumbnailLink = string.Concat(startLink, midLink2, endLink);

            if (string.IsNullOrEmpty(thumbnailLink))
            {
                return "https://i.ytimg.com/vi/1/0.jpg";
            }

            return thumbnailLink;
        }

        public string GetEmbededVideoLink(string videoUrl)
        {
            if (string.IsNullOrEmpty(videoUrl))
            {
                return "none";
            }

            string embedVideoLink = videoUrl;
            embedVideoLink = embedVideoLink
                .Replace("https://www.youtube.com/watch?v=", "");

            embedVideoLink = embedVideoLink
                .Replace("https://youtu.be/", "");

            if (string.IsNullOrEmpty(embedVideoLink))
            {
                return "none";
            }

            if (embedVideoLink.Contains('&'))
            {
                embedVideoLink = embedVideoLink.Substring(0, embedVideoLink.IndexOf('&'));
            }

            return embedVideoLink;
        }

        public async Task<bool> IncrementViews(int id)
        {
            this.videoRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefault()
                .TimesSeen += 1;

            await this.videoRepository.SaveChangesAsync();

            return true;
        }

        public async Task EditAsync(int videoId, string title, string description, string videoUrl)
        {
            var video = this.GetById(videoId);
            video.Title = title;
            video.Description = description;
            video.VideoUrl = videoUrl;

            await this.videoRepository.SaveChangesAsync();

            return;
        }
    }
}
