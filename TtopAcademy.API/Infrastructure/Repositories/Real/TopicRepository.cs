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
    /// <summary> Topic repository class. </summary>
    public class TopicRepository : ITopicRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new topic repository with given parameter. </summary> 
        public TopicRepository(IApplicationDbContext context)
        {
            this.context = context; 
        }
         
        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return await Task.FromResult(context.Topics);
        }

        public async Task<Topic> DeleteTopicAsync(int topicID)
        {
            Topic dbEntry = await context.Topics.FindAsync(topicID);
            if (dbEntry != null)
            {
                context.Topics.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<Topic> SaveTopicAsync(Topic topic)
        {
            context.Topics.Add(topic);
            await context.SaveChangesAsync();
            return GetTopic(topic.Name, topic.Number);
        }

        public async Task<Topic> UpdateTopicAsync(Topic topic)
        {
            Topic dbEntry = await context.Topics.FindAsync(topic.TopicID);
            if (dbEntry != null)
            {
                dbEntry.Number = topic.Number;
                dbEntry.Name = topic.Name;
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        private Topic GetTopic(string topicName, int topicNumber)
        {
            return context.Topics.FirstOrDefault(p => p.Name == topicName && p.Number == topicNumber);
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