using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Real
{
    /// <summary> CategorySubjectTopicVideo repository class. </summary>  
    public class CategorySubjectTopicVideoRepository : ICategorySubjectTopicVideoRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new CategorySubjectTopicVideo repository with given parameter. </summary> 
        public CategorySubjectTopicVideoRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategorySubjectTopicVideo>> GetAllAsync()
        {
            return  await Task.FromResult(context.CategorySubjectTopicVideos);
        }

        public async Task<IEnumerable<CategorySubjectTopicVideo>> 
            GetCategorySubjectTopicVideosAsync(int categoryID, int subjectID, int topicID)
        {
            return await Task.FromResult(
                context.CategorySubjectTopicVideos.Where(p => p.CategorySubjectTopic.TopicID == topicID &&
                                                           p.CategorySubjectTopic.CategorySubject.CategoryID == categoryID
                                                           && p.CategorySubjectTopic.CategorySubject.SubjectID == subjectID)
            );
        }

        public async Task<IEnumerable<CategorySubjectTopicVideo>> GetCategorySubjectTopicVideosAsync(int categorySubjectTopicID)
        {
            return await Task.FromResult(context.CategorySubjectTopicVideos.Where(c => c.CategorySubjectTopicID == categorySubjectTopicID));
        }

        public async Task<CategorySubjectTopicVideo> GetCategorySubjectTopicVideoAsync(int categoryID, int subjectID, int topicID, int videoID)
        {
            return await Task.FromResult(context.CategorySubjectTopicVideos.FirstOrDefault(p => p.VideoID == videoID && p.CategorySubjectTopic.TopicID == topicID
                                                                                && p.CategorySubjectTopic.CategorySubject.SubjectID == subjectID
                                                                                && p.CategorySubjectTopic.CategorySubject.CategoryID == categoryID)); 
        }

        public async Task<CategorySubjectTopicVideo> DeleteCategorySubjectTopicVideoAsync(int categoryID, int subjectID, int topicID, int videoID)
        {
            CategorySubjectTopicVideo dbEntry = await Task.FromResult(
                context.CategorySubjectTopicVideos.FirstOrDefault(c => c.VideoID == videoID && c.CategorySubjectTopic.TopicID == topicID
                                                    && c.CategorySubjectTopic.CategorySubject.CategoryID == categoryID
                                                    && c.CategorySubjectTopic.CategorySubject.SubjectID == subjectID)
            );
            if (dbEntry != null)
            {
                context.CategorySubjectTopicVideos.Remove(dbEntry);
                await context.SaveChangesAsync(); 
            }
            return dbEntry;
        }

        public async Task<CategorySubjectTopicVideo> SaveCategorySubjectTopicVideoAsync(CategorySubjectTopicVideo categorySubjectTopicVideo)
        {
            context.CategorySubjectTopicVideos.Add(categorySubjectTopicVideo);
            await context.SaveChangesAsync();
            return GetCategorySubjectTopicVideo(categorySubjectTopicVideo.CategorySubjectTopicID,
                categorySubjectTopicVideo.VideoID);
        }

        private CategorySubjectTopicVideo GetCategorySubjectTopicVideo(int categorySubjectTopicID, int videoID)
        {
            return context.CategorySubjectTopicVideos.
                FirstOrDefault(c => c.VideoID == videoID && c.CategorySubjectTopicID == categorySubjectTopicID); 
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