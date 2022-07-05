using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;

namespace TtopAcademy.API.Infrastructure.Managers.Fakes
{
    /// <summary> Fake topic manager implemetation class. Used for unit testing. </summary>
    public class FakeTopicManager : ITopicManager
    {
        private readonly List<CategorySubjectTopic> categorySubjectTopics;

        /// <summary> Constructs a new FakeTopicManager with given parameter. </summary>
        public FakeTopicManager(List<CategorySubjectTopic> categorySubjectTopics)
        {
            this.categorySubjectTopics = categorySubjectTopics;
        }

        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            List<Topic> topics = new List<Topic>();
            foreach (CategorySubjectTopic categorySubjectTopic in categorySubjectTopics)
            {
                topics.Add(categorySubjectTopic.Topic);
            }
            return await Task.FromResult(topics);
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync(int categoryID, int subjectID)
        {
            List<Topic> topics = new List<Topic>();
            foreach (CategorySubjectTopic categorySubjectTopic in categorySubjectTopics)
            {
                if (categorySubjectTopic.CategorySubject.CategoryID == categoryID
                    && categorySubjectTopic.CategorySubject.SubjectID == subjectID)
                {
                    topics.Add(categorySubjectTopic.Topic);
                }
            }
            return await Task.FromResult(topics);
        }

        public async Task<Topic> SaveTopicAsync(int categoryID, int subjectID, Topic topic)
        {
            foreach (CategorySubjectTopic categorySubjectTopic in categorySubjectTopics)
            {
                if (categorySubjectTopic.CategorySubject.CategoryID == categoryID
                    && categorySubjectTopic.CategorySubject.SubjectID == subjectID)
                {
                    topic.TopicID = 100;
                    categorySubjectTopic.Topic = topic;
                    break;
                }
            }
            return await Task.FromResult(topic);
        }

        public async Task<Topic> UpdateTopicAsync(Topic topic)
        {
            foreach (CategorySubjectTopic categorySubjectTopic in categorySubjectTopics)
            {
                if (categorySubjectTopic.TopicID == topic.TopicID)
                {
                    categorySubjectTopic.Topic = topic;
                    break;
                }
            }
            return await Task.FromResult(topic);
        }

        public async Task<Topic> DeleteTopicAsync(int topicID, int subjectID, int categoryID)
        {
            CategorySubjectTopic categorySubjectTopic =
                categorySubjectTopics.FirstOrDefault(c => c.TopicID == topicID
                        && c.CategorySubject.SubjectID == subjectID
                        && c.CategorySubject.CategoryID == categoryID);
            if (categorySubjectTopic == null)
            {
                return null;
            }
            await Task.FromResult(categorySubjectTopics.Remove(categorySubjectTopic));
            return categorySubjectTopic.Topic;
        }
    }
}