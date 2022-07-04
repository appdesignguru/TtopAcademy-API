using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;

namespace TtopAcademy.API.Infrastructure.Managers.Fakes
{
    public class FakeVideoManager : IVideoManager
    {
        private readonly List<CategorySubjectTopicVideo> categorySubjectTopicVideos;

        public FakeVideoManager(List<CategorySubjectTopicVideo> categorySubjectTopicVideos)
        {
            this.categorySubjectTopicVideos = categorySubjectTopicVideos;
        }

        public async Task<IEnumerable<Video>> GetAllVideosAsync()
        {
            List<Video> videos = new List<Video>();
            foreach (CategorySubjectTopicVideo categorySubjectTopicVideo in categorySubjectTopicVideos)
            {
                videos.Add(categorySubjectTopicVideo.Video);
            }
            return await Task.FromResult(videos);
        }

        public async Task<IEnumerable<Video>> GetVideosAsync(int categoryID, int subjectID, int topicID)
        {
            List<Video> videos = new List<Video>();
            foreach (CategorySubjectTopicVideo categorySubjectTopicVideo in categorySubjectTopicVideos)
            {
                if (categorySubjectTopicVideo.CategorySubjectTopic.TopicID == topicID
                    && categorySubjectTopicVideo.CategorySubjectTopic.CategorySubject.SubjectID == subjectID
                    && categorySubjectTopicVideo.CategorySubjectTopic.CategorySubject.CategoryID == categoryID)
                {
                    videos.Add(categorySubjectTopicVideo.Video);
                    break;
                }
            }
            return await Task.FromResult(videos);
        }

        public async Task<IEnumerable<Video>> GetVideosAsync(int categorySubjectTopicID)
        {
            List<Video> videos = new List<Video>();
            foreach (CategorySubjectTopicVideo categorySubjectTopicVideo in categorySubjectTopicVideos)
            {
                if (categorySubjectTopicVideo.CategorySubjectTopicID == categorySubjectTopicID)
                {
                    videos.Add(categorySubjectTopicVideo.Video);
                    break;
                }
            }
            return await Task.FromResult(videos);
        } 

        public async Task<Video> SaveVideoAsync(int categoryID, int subjectID, int topicID, Video video)
        {
            Video videos = new Video();
            foreach (CategorySubjectTopicVideo categorySubjectTopicVideo in categorySubjectTopicVideos)
            {
                if (categorySubjectTopicVideo.CategorySubjectTopic.TopicID == topicID
                    && categorySubjectTopicVideo.CategorySubjectTopic.CategorySubject.CategoryID == categoryID
                    && categorySubjectTopicVideo.CategorySubjectTopic.CategorySubject.SubjectID == subjectID) 
                {
                    video.VideoID = 100;
                    categorySubjectTopicVideo.Video = video;
                    break;
                }
            }
            return await Task.FromResult(video);
        }

        public async Task<Video> UpdateVideoAsync(Video video)
        {
            Video videos = new Video();
            foreach (CategorySubjectTopicVideo categorySubjectTopicVideo in categorySubjectTopicVideos)
            {
                if (categorySubjectTopicVideo.VideoID == video.VideoID)
                {
                    categorySubjectTopicVideo.Video = video;
                    break;
                }
            }
            return await Task.FromResult(video);
        }


        public async Task<Video> DeleteVideoAsync(int videoID, int topicID, int subjectID, int categoryID)
        {
            CategorySubjectTopicVideo categorySubjectTopicVideo
                = categorySubjectTopicVideos.FirstOrDefault(c => c.VideoID == videoID
                    && c.CategorySubjectTopic.TopicID == topicID
                    && c.CategorySubjectTopic.CategorySubject.CategoryID == categoryID
                    && c.CategorySubjectTopic.CategorySubject.SubjectID == subjectID);
            if (categorySubjectTopicVideo == null)
            {
                return null;
            }
            await Task.FromResult(categorySubjectTopicVideos.Remove(categorySubjectTopicVideo));
            return categorySubjectTopicVideo.Video;
        }
    }
}