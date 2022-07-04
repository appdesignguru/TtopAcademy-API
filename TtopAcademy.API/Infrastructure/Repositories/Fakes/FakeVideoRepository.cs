using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    public class FakeVideoRepository : IVideoRepository
    {
        private readonly List<Video> videos;

        public FakeVideoRepository(List<Video> videos)
        {
            this.videos = videos;
        }

        public async Task<IEnumerable<Video>> GetAllVideosAsync() 
        {
            return await Task.FromResult(videos);
        } 

        public async Task<Video> DeleteVideoAsync(int videoID)
        {
            return await Task.FromResult(DeleteVideo(videoID));
        }

        public async Task<Video> SaveVideoAsync(Video video)
        {
            return await Task.FromResult(SaveVideo(video));
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            return await Task.FromResult(UpdateVideo(video));
        }

        private Video DeleteVideo(int videoID)
        {
            Video video = videos.FirstOrDefault(c => c.VideoID == videoID);
            if (video != null)
            {
                videos.Remove(video);
            }
            return video;
        }

        private Video SaveVideo(Video video)
        {
            Video entry = new Video
            {
                VideoID = video.VideoID,
                Number = video.Number,
                YoutubeID = video.YoutubeID,
                Title = video.Title,
                Size = video.Size,
                SolutionVideoYoutubeID = video.SolutionVideoYoutubeID,
                SolutionVideoSize = video.SolutionVideoSize,
            };
            videos.Add(entry);
            return entry;
        }

        private Video UpdateVideo(Video video)
        {
            Video entry = videos.FirstOrDefault(c => c.VideoID == video.VideoID);
            if (entry != null)
            {
                entry.Number = video.Number;
                entry.YoutubeID = video.YoutubeID;
                entry.Title = video.Title;
                entry.Size = video.Size;
                entry.SolutionVideoYoutubeID = video.SolutionVideoYoutubeID;
                entry.SolutionVideoSize = video.SolutionVideoSize;
            }
            return entry;
        }
    }
}