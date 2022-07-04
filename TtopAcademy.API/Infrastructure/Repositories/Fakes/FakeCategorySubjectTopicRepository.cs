using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    public class FakeCategorySubjectTopicRepository : ICategorySubjectTopicRepository
    {
        private readonly List<CategorySubjectTopic> categorySubjectTopics;

        public FakeCategorySubjectTopicRepository(List<CategorySubjectTopic> categorySubjectTopics)
        {
            this.categorySubjectTopics = categorySubjectTopics;
        }

        public async Task<IEnumerable<CategorySubjectTopic>> GetAllCategorySubjectTopicsAsync()
        {
            return await Task.FromResult(categorySubjectTopics);
        }

        public async Task<IEnumerable<CategorySubjectTopic>> GetCategorySubjectTopicsAsync(int categoryID, int subjectID)
        {
            return await Task.FromResult(categorySubjectTopics.Where(p => p.CategorySubject.CategoryID == categoryID 
                                                     && p.CategorySubject.SubjectID == subjectID));
        }

        public async Task<CategorySubjectTopic> GetCategorySubjectTopicAsync(int categoryID, int subjectID, int topicID)
        {
            return await Task.FromResult(categorySubjectTopics.FirstOrDefault(q => q.TopicID == topicID &&
                                                                    q.CategorySubject.CategoryID == categoryID
                                                                    && q.CategorySubject.SubjectID == subjectID));
        }

        public async Task<int> GetCategorySubjectTopicIDAsync(int categorySubjectID, int topicID)
        {
            return await Task.FromResult(categorySubjectTopics.FirstOrDefault(p => p.TopicID == topicID && 
                                                                                   p.CategorySubjectID == categorySubjectID
                                                                                    ).CategorySubjectTopicID);
        }

        public Task<CategorySubjectTopic> DeleteCategorySubjectTopicAsync(int categoryID, int subjectID, int topicID)
        {
            return Task.FromResult(DeleteCategorySubjectTopic(categoryID, subjectID, topicID)); 
        }

        public async Task<CategorySubjectTopic> SaveCategorySubjectTopicAsync(CategorySubjectTopic categorySubjectTopic)
        {
            return await Task.FromResult(SaveCategorySubjectTopic(categorySubjectTopic));
        }

        private CategorySubjectTopic DeleteCategorySubjectTopic(int categoryID, int subjectID, int topicID) 
        {
            CategorySubjectTopic categorySubjectTopic = categorySubjectTopics.FirstOrDefault(q => q.TopicID == topicID &&
                                                                    q.CategorySubject.CategoryID == categoryID
                                                                    && q.CategorySubject.SubjectID == subjectID);
            if (categorySubjectTopic != null)
            {
                categorySubjectTopics.Remove(categorySubjectTopic);
            }
            return categorySubjectTopic; 
        }

        private CategorySubjectTopic SaveCategorySubjectTopic(CategorySubjectTopic categorySubjectTopic)
        {
            CategorySubjectTopic entry = new CategorySubjectTopic
            {
                CategorySubjectTopicID = 300,
                CategorySubjectID = categorySubjectTopic.CategorySubjectID,
                TopicID = categorySubjectTopic.TopicID
            };
            categorySubjectTopics.Add(entry);
            return entry;
        }
    }
}