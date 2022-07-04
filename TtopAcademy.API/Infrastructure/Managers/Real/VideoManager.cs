using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Managers.Real
{
    /// <summary> Class for managing videos. </summary> 
    public class VideoManager : IVideoManager
    { 
        private readonly IVideoRepository videoRepository;
        private readonly ICategorySubjectTopicRepository categorySubjectTopicRepository;
        private readonly ICategorySubjectTopicVideoRepository categorySubjectTopicVideoRepository;

        /// <summary> Constructs a new video manager with given parameters. </summary>  
        public VideoManager(IVideoRepository videoRepository, ICategorySubjectTopicRepository categorySubjectTopicRepository,
                                    ICategorySubjectTopicVideoRepository categorySubjectTopicVideoRepository)
        {
            this.videoRepository = videoRepository;
            this.categorySubjectTopicRepository = categorySubjectTopicRepository;
            this.categorySubjectTopicVideoRepository = categorySubjectTopicVideoRepository;
        }

        public async Task<IEnumerable<Video>> GetAllVideosAsync()
        {
            return await videoRepository.GetAllVideosAsync();
        }

        public async Task<IEnumerable<Video>> GetVideosAsync(int categoryID, int subjectID, int topicID)
        {
            IEnumerable<CategorySubjectTopicVideo> categorySubjectTopicVideos
                = await categorySubjectTopicVideoRepository.GetCategorySubjectTopicVideosAsync
                    (categoryID, subjectID, topicID);

            IEnumerable<Video> videos = GetVideos(categorySubjectTopicVideos);

            return videos;
        }

        public async Task<IEnumerable<Video>> GetVideosAsync(int categorySubjectTopicID)
        {

            IEnumerable<CategorySubjectTopicVideo> categorySubjectTopicVideos
                = await categorySubjectTopicVideoRepository.GetCategorySubjectTopicVideosAsync
                    (categorySubjectTopicID);

            IEnumerable<Video> videos = GetVideos(categorySubjectTopicVideos);

            return videos;
        }

        public async Task<Video> SaveVideoAsync(int categoryID, int subjectID, int topicID, Video video)
        {
            Video dbEntry = await videoRepository.SaveVideoAsync(video);
            await SaveCategorySubjectTopicVideo(video.VideoID, topicID, subjectID, categoryID);
            return dbEntry;
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            return await videoRepository.UpdateVideoAsync(video);
        } 

        public async Task<Video> DeleteVideoAsync(int videoID, int topicID, int subjectID, int categoryID)
        {
            CategorySubjectTopicVideo categorySubjectTopicVideo
                = await categorySubjectTopicVideoRepository.DeleteCategorySubjectTopicVideoAsync(
                    categoryID, subjectID, topicID, videoID);
            Video video = await videoRepository.DeleteVideoAsync(videoID);
            if (categorySubjectTopicVideo == null || video == null)
            {
                return null;
            }
            return video;
        }

        private async Task SaveCategorySubjectTopicVideo(int videoID, int topicID, int subjectID, int categoryID)
        {
            CategorySubjectTopicVideo categorySubjectTopicVideo =
             await categorySubjectTopicVideoRepository.GetCategorySubjectTopicVideoAsync(categoryID, subjectID, topicID, videoID);

            if (categorySubjectTopicVideo == null)
            {
                CategorySubjectTopic categorySubjectTopic = await categorySubjectTopicRepository.GetCategorySubjectTopicAsync(categoryID, subjectID, topicID);
                await categorySubjectTopicVideoRepository.SaveCategorySubjectTopicVideoAsync(new CategorySubjectTopicVideo
                {
                    VideoID = videoID,
                    CategorySubjectTopicID = categorySubjectTopic.CategorySubjectTopicID
                });
            }
        }

        private IEnumerable<Video> GetVideos(IEnumerable<CategorySubjectTopicVideo> categorySubjectTopicVideos)
        {
            List<Video> videos = new List<Video>();
            foreach (CategorySubjectTopicVideo categorySubjectTopicVideo in categorySubjectTopicVideos)
            {
                videos.Add(categorySubjectTopicVideo.Video);
            }
            return videos;
        }
    }
}