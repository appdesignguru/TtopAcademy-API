using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    public class FakeCategorySubjectTopicVideoRepository : ICategorySubjectTopicVideoRepository
    {
        private readonly List<CategorySubjectTopicVideo> categorySubjectTopicVideos;

        public FakeCategorySubjectTopicVideoRepository(List<CategorySubjectTopicVideo> categorySubjectTopicVideos)
        {
            this.categorySubjectTopicVideos = categorySubjectTopicVideos;
        }

        public async Task<IEnumerable<CategorySubjectTopicVideo>> GetAllAsync()
        {
            return await Task.FromResult(categorySubjectTopicVideos);
        }

        public async Task<IEnumerable<CategorySubjectTopicVideo>>
            GetCategorySubjectTopicVideosAsync(int categoryID, int subjectID, int topicID)
        {
            return await Task.FromResult(
                categorySubjectTopicVideos.Where(p => p.CategorySubjectTopic.TopicID == topicID &&
                                                    p.CategorySubjectTopic.CategorySubject.CategoryID == categoryID
                                                    && p.CategorySubjectTopic.CategorySubject.SubjectID == subjectID));
        }

        public async Task<IEnumerable<CategorySubjectTopicVideo>> GetCategorySubjectTopicVideosAsync(int categorySubjectTopicID)
        {
            return await Task.FromResult(categorySubjectTopicVideos.Where(c => c.CategorySubjectTopicID == categorySubjectTopicID));
        }

        public async Task<CategorySubjectTopicVideo> GetCategorySubjectTopicVideoAsync(int categoryID, int subjectID, int topicID, int videoID)
        {
            return await Task.FromResult(categorySubjectTopicVideos.FirstOrDefault(p => p.VideoID == videoID && p.CategorySubjectTopic.TopicID == topicID
                                                                                && p.CategorySubjectTopic.CategorySubject.SubjectID == subjectID
                                                                                && p.CategorySubjectTopic.CategorySubject.CategoryID == categoryID));
        }

        public Task<CategorySubjectTopicVideo> DeleteCategorySubjectTopicVideoAsync(int categoryID, int subjectID, int topicID, int videoID)
        {
            return Task.FromResult(DeleteCategorySubjectTopicVideo(categoryID,subjectID, topicID, videoID));
        }
         
        public async Task<CategorySubjectTopicVideo> SaveCategorySubjectTopicVideoAsync(CategorySubjectTopicVideo categorySubjectTopicVideo)
        {
             return await Task.FromResult(SaveCategorySubjectTopicVideo(categorySubjectTopicVideo));
        }

        private CategorySubjectTopicVideo DeleteCategorySubjectTopicVideo(int categoryID, int subjectID, int topicID, int videoID)
        {
            CategorySubjectTopicVideo categorySubjectTopicVideo =
                categorySubjectTopicVideos.FirstOrDefault(c => c.VideoID == videoID && c.CategorySubjectTopic.TopicID == topicID
                                                    && c.CategorySubjectTopic.CategorySubject.CategoryID == categoryID
                                                    && c.CategorySubjectTopic.CategorySubject.SubjectID == subjectID);
            if (categorySubjectTopicVideo != null)
            {
                categorySubjectTopicVideos.Remove(categorySubjectTopicVideo);
            }
            return categorySubjectTopicVideo;
        }

        private CategorySubjectTopicVideo SaveCategorySubjectTopicVideo(CategorySubjectTopicVideo categorySubjectTopicVideo)
        {
            CategorySubjectTopicVideo entry = new CategorySubjectTopicVideo
            {
                CategorySubjectTopicVideoID = 400,
                CategorySubjectTopicID = categorySubjectTopicVideo.CategorySubjectTopicID,
                VideoID = categorySubjectTopicVideo.VideoID
            };
            categorySubjectTopicVideos.Add(entry);
            
            return entry;
        }
    }
}