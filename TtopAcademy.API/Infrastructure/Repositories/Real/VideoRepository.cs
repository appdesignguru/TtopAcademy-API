using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Models;

namespace TtopAcademy.API.Infrastructure.Repositories.Real
{
    /// <summary> Video repository class. </summary> 
    public class VideoRepository : IVideoRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new video repository with given parameter. </summary> 
        public VideoRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Video>> GetAllVideosAsync() 
        {
            return await Task.FromResult(context.Videos);
        }

        public async Task<Video> DeleteVideoAsync(int videoID)
        {
            Video dbEntry = await context.Videos.FindAsync(videoID);
            if (dbEntry != null)
            {
                context.Videos.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<Video> SaveVideoAsync(Video video)
        {
            context.Videos.Add(video);
            await context.SaveChangesAsync();
            return GetVideo(video.YoutubeID);
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            Video dbEntry = await context.Videos.FindAsync(video.VideoID); 
            if (dbEntry != null)
            {
                dbEntry.Number = video.Number;
                dbEntry.YoutubeID = video.YoutubeID;
                dbEntry.Title = video.Title;
                dbEntry.Size = video.Size;
                dbEntry.SolutionVideoYoutubeID = video.SolutionVideoYoutubeID;
                dbEntry.SolutionVideoSize = video.SolutionVideoSize;
            }
            await context.SaveChangesAsync();
            return video;
        }

        private Video GetVideo(string youtubeID)
        {
            return context.Videos.Where(p => p.YoutubeID == youtubeID).FirstOrDefault();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}