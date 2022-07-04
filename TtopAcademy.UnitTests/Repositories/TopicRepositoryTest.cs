using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.ApplicationDbContext.Fakes;
using TtopAcademy.API.Infrastructure.Repositories.Real;

namespace TtopAcademy.UnitTests.Repositories
{
    [TestClass] 
    public class TopicRepositoryTest
    {
        ITopicRepository topicRepository;
        IApplicationDbContext applicationDbContext;
        Topic dbEntry; 

        [TestInitialize]
        public async Task InitializeBeforeEachTest() 
        {
            applicationDbContext = new FakeApplicationDbContext();
            topicRepository = new TopicRepository(applicationDbContext);

            // PreSave
            Topic topic = new Topic { Number = 1, Name = "Set" };
            dbEntry = await topicRepository.SaveTopicAsync(topic);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            topicRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            IEnumerable<Topic> results = await topicRepository.GetAllTopicsAsync();

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod] 
        public async Task SaveTopicAsync_ShouldReturnSavedEntry()
        {
            Topic topic = new Topic { Number = 2, Name = "Logarithm" };
            var result = await topicRepository.SaveTopicAsync(topic);

            Assert.AreEqual(topic.Number, result.Number);
            Assert.AreEqual(topic.Name, result.Name);
        }

        [TestMethod]
        public async Task UpdateTopicAsync_ShouldReturnEditedEntry()
        {
            Topic topic = new Topic { TopicID = dbEntry.TopicID, Number = 1, Name = "Set Theory" };
            Topic result = await topicRepository.UpdateTopicAsync(topic);

            Assert.AreEqual(topic.Number, result.Number);
            Assert.AreEqual(topic.Name, result.Name);
        }

        [TestMethod]
        public async Task DeleteTopicAsync_ShouldReturnDeletedSubject()
        {
            Topic result = await topicRepository.DeleteTopicAsync(dbEntry.TopicID);

            Assert.AreEqual(dbEntry.Number, result.Number);
            Assert.AreEqual(dbEntry.Name, result.Name);
        }
    }
}
