using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    public class FakeTopicRepository : ITopicRepository
    {
        private readonly List<Topic> topics;

        public FakeTopicRepository(List<Topic> topics)
        {
            this.topics = topics;
        } 

        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return await Task.FromResult(topics);
        }

        public async Task<Topic> DeleteTopicAsync(int topicID)
        {
            return await Task.FromResult(DeleteTopic(topicID));
        }

        public async Task<Topic> SaveTopicAsync(Topic topic)
        {
            return await Task.FromResult(SaveTopic(topic));
        }

        public async Task<Topic> UpdateTopicAsync(Topic topic)
        {
            return await Task.FromResult(UpdateTopic(topic));
        }

        private Topic DeleteTopic(int topicID)
        {
            Topic topic = topics.FirstOrDefault(c => c.TopicID == topicID);
            if (topic != null)
            {
                topics.Remove(topic);
            }
            return topic;
        }

        private Topic SaveTopic(Topic topic)
        {
            Topic entry = new Topic
            {
                TopicID = 600,
                Number = topic.Number,
                Name = topic.Name
            };
            return entry;
        }

        private Topic UpdateTopic(Topic topic)
        {
            Topic entry = topics.FirstOrDefault(c => c.TopicID == topic.TopicID);
            if (entry != null)
            {
                entry.TopicID = topic.TopicID;
                entry.Number = topic.Number;
                entry.Name = topic.Name;
            }
            return entry;
        }
    }
}