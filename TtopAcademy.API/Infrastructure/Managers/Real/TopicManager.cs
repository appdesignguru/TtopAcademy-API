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
    /// <summary> Class for managing topics. </summary> 
    public class TopicManager : ITopicManager
    {
        private readonly ITopicRepository topicRepository;
        private readonly ICategorySubjectRepository categorySubjectRepository;
        private readonly ICategorySubjectTopicRepository categorySubjectTopicRepository;

        /// <summary> Constructs a new topic manager with given parameters. </summary>  
        public TopicManager(ITopicRepository topicRepository,
                    ICategorySubjectRepository categorySubjectRepository,
                    ICategorySubjectTopicRepository categorySubjectTopicRepository)
        {
            this.topicRepository = topicRepository;
            this.categorySubjectRepository = categorySubjectRepository;
            this.categorySubjectTopicRepository = categorySubjectTopicRepository;
        }


        public Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return topicRepository.GetAllTopicsAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync(int categoryID, int subjectID)
        {
            IEnumerable<CategorySubjectTopic> categorySubjectTopics =
                await categorySubjectTopicRepository.GetCategorySubjectTopicsAsync(categoryID, subjectID);
            List<Topic> topics = GetTopics(categorySubjectTopics);
            return topics;
        }

        public async Task<Topic> SaveTopicAsync(int categoryID, int subjectID, Topic topic)
        {
            Topic dbEntry = await topicRepository.SaveTopicAsync(topic);
            await SaveCategorySubjectTopicAync(topic.TopicID, subjectID, categoryID);
            return dbEntry;
        }

        public async Task<Topic> UpdateTopicAsync(Topic topic)
        {
            Topic dbEntry = await topicRepository.UpdateTopicAsync(topic);
            return dbEntry;
        }


        public async Task<Topic> DeleteTopicAsync(int topicID, int subjectID, int categoryID)
        {
            CategorySubjectTopic categorySubjectTopic =
                await categorySubjectTopicRepository.DeleteCategorySubjectTopicAsync(categoryID, subjectID, topicID);
            Topic topic = await topicRepository.DeleteTopicAsync(topicID);
            if (categorySubjectTopic == null || topic == null)
            {
                return null;
            }
            return topic;
        }

        #region Helpers 

        private async Task SaveCategorySubjectTopicAync(int topicID, int subjectID, int categoryID)
        {
            CategorySubjectTopic categorySubjectTopic = await categorySubjectTopicRepository
                .GetCategorySubjectTopicAsync(categoryID, subjectID, topicID);
            if (categorySubjectTopic == null)
            {
                CategorySubject categorySubject = await categorySubjectRepository
                    .GetCategorySubjectAsync(categoryID, subjectID);
                await categorySubjectTopicRepository.SaveCategorySubjectTopicAsync(
                    new CategorySubjectTopic
                    {
                        CategorySubjectID = categorySubject.CategorySubjectID,
                        TopicID = topicID
                    }
                );
            }
        }

        private List<Topic> GetTopics(IEnumerable<CategorySubjectTopic> categorySubjectTopics)
        {
            List<Topic> topics = new List<Topic>();
            foreach (CategorySubjectTopic categorySubjectTopic in categorySubjectTopics)
            {
                topics.Add(categorySubjectTopic.Topic);
            }
            return topics;
        }

        #endregion
    }
}