namespace PokerStrategy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PokerStrategy.Data.Models;

    public interface IVideosService
    {
        Task<int> CreateAsync(string title, string desc, string url, string category);

        Task Delete(int id);

        Video GetById(int id);

        Task<bool> IncrementViews(int id);

        IEnumerable<Video> GetAll();

        IEnumerable<Video> GetLatestVideos();

        string GetThumbnailLink(string videoUrl);

        string GetEmbededVideoLink(string videoUrl);
    }
}
