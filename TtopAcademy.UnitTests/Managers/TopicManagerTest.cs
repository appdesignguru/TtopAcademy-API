using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.Managers.Real;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;

namespace TtopAcademy.UnitTests.Managers
{
    [TestClass] 
    public class TopicManagerTest
    {
        private ITopicManager topicManager;
        private List<CategorySubject> testCategorySubjects;
        private List<CategorySubjectTopic> testCategorySubjectTopics;
        private List<Topic> testTopics;

        [TestInitialize]
        public void InitializeBeforeEachTest() 
        {
            testCategorySubjects = GetTestCategorySubjects();
            testCategorySubjectTopics = GetTestCegorySubjectTopics();
            testTopics = GetTestTopics();
            ICategorySubjectRepository fakeCategorySubjectRepository =
                new FakeCategorySubjectRepository(testCategorySubjects);
            ICategorySubjectTopicRepository fakeCategorySubjectTopicRepository =
                new FakeCategorySubjectTopicRepository(testCategorySubjectTopics);
            ITopicRepository fakeTopicRepository = new FakeTopicRepository(testTopics);
            topicManager = new TopicManager(fakeTopicRepository,
                fakeCategorySubjectRepository, fakeCategorySubjectTopicRepository);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testCategorySubjects = null;
            testCategorySubjectTopics = null;
            testTopics = null;
            topicManager = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll() 
        {
            IEnumerable<Topic> result = await topicManager.GetAllTopicsAsync() as IEnumerable<Topic>;
            Assert.AreEqual(testTopics.Count(), result.Count());
        }

        [TestMethod]
        public async Task GetSubjectsAsync_ShouldReturnForCategoryAndSubjectID()
        {
            int categoryID = 1, subjectID = 1;
            IEnumerable<Topic> result = await topicManager.GetTopicsAsync(categoryID, subjectID);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod] 
        public async Task SaveTopicAsync_ShouldReturnPostedEntry()
        {
            int categoryID = 1, subjectID = 1;
            Topic topic = new Topic {
                TopicID = 1, Number = 3, Name = "Geometry"
            };
            var result = await topicManager.SaveTopicAsync(categoryID, subjectID, topic);

            Assert.IsNotNull(result);
            Assert.AreEqual(topic.Name, result.Name); 
        }

        [TestMethod]
        public async Task UpdateTopicAsync_ShouldEditedEntry() 
        {
            Topic topic = new Topic {
                TopicID = 2, Number = 2, Name = "Set Theory" 
            };
            Topic result = await topicManager.UpdateTopicAsync(topic);

            Assert.IsNotNull(result);
            Assert.AreEqual(topic.Name, result.Name); 
        }

        [TestMethod]
        public async Task DeleteTopicAsync_ShouldDeletedEntry() 
        {
            int topicID =1, subjectID = 1, categoryID = 1;
            Topic result = 
                await topicManager.DeleteTopicAsync(topicID, subjectID, categoryID);

            Assert.IsNotNull(result); 
        }

        private List<CategorySubject> GetTestCategorySubjects()
        {
            var testCategorySubjects = new List<CategorySubject> {
                new CategorySubject { CategorySubjectID = 1, CategoryID = 1, SubjectID = 1},
                new CategorySubject { CategorySubjectID = 2, CategoryID = 1, SubjectID = 2},
            };
            return testCategorySubjects;
        }

        private List<CategorySubjectTopic> GetTestCegorySubjectTopics()
        {
            var testCategorySubjectTopics = new List<CategorySubjectTopic>
            {
                new CategorySubjectTopic {
                    CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                    CategorySubject = new CategorySubject { CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                },
                new CategorySubjectTopic {
                    CategorySubjectTopicID = 2, CategorySubjectID = 1, TopicID = 2,
                    CategorySubject = new CategorySubject { CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                }
            };
            return testCategorySubjectTopics;
        }

        private List<Topic> GetTestTopics()
        {
            var testTopics = new List<Topic>
            {
                new Topic { TopicID = 1, Number = 1, Name = "Calculus" },
                new Topic { TopicID = 2, Number = 2, Name = "Set" }

            };
            return testTopics;
        }
    }
}
