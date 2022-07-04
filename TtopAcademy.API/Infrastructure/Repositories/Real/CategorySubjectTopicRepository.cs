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
    /// <summary> CategorySubjectTopic repository class. </summary> 
    public class CategorySubjectTopicRepository : ICategorySubjectTopicRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new CategorySubjectTopic repository with given parameter. </summary> 
        public CategorySubjectTopicRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategorySubjectTopic>> GetAllCategorySubjectTopicsAsync()
        {
            return await Task.FromResult(context.CategorySubjectTopics);
        }

        public async Task<IEnumerable<CategorySubjectTopic>> GetCategorySubjectTopicsAsync(int categoryID, int subjectID)
        {
            return await Task.FromResult(
                context.CategorySubjectTopics.Where(p => p.CategorySubject.CategoryID == categoryID
                                                     && p.CategorySubject.SubjectID == subjectID)
            );
        }

        public async Task<CategorySubjectTopic> GetCategorySubjectTopicAsync(int categoryID, int subjectID, int topicID)
        {
            return await Task.FromResult(context.CategorySubjectTopics.FirstOrDefault(q => q.TopicID == topicID &&
                                                                    q.CategorySubject.CategoryID == categoryID
                                                                    && q.CategorySubject.SubjectID == subjectID));
        }

        public async Task<int> GetCategorySubjectTopicIDAsync(int categorySubjectID, int topicID)
        {
            return await Task.FromResult(context.CategorySubjectTopics.FirstOrDefault(p => p.TopicID == topicID && 
                                                                                        p.CategorySubjectID == categorySubjectID)
                                                                                        .CategorySubjectTopicID);
        }

        public async Task<CategorySubjectTopic> DeleteCategorySubjectTopicAsync(int categoryID, int subjectID, int topicID) 
        {
            CategorySubjectTopic dbEntry = await Task.FromResult(context.CategorySubjectTopics.FirstOrDefault(q => q.TopicID == topicID &&
                                                                    q.CategorySubject.CategoryID == categoryID
                                                                    && q.CategorySubject.SubjectID == subjectID));
            if (dbEntry != null)
            {
                context.CategorySubjectTopics.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<CategorySubjectTopic> SaveCategorySubjectTopicAsync(CategorySubjectTopic categorySubjectTopic)
        {
            context.CategorySubjectTopics.Add(categorySubjectTopic);
            await context.SaveChangesAsync();
            return GetCategorySubjectTopic(categorySubjectTopic.CategorySubjectID, categorySubjectTopic.TopicID);
        }

        private CategorySubjectTopic GetCategorySubjectTopic(int categorySubjectID, int topicID)
        {
            return context.CategorySubjectTopics.
                FirstOrDefault(c => c.TopicID == topicID && c.CategorySubjectID == categorySubjectID);
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