using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Managers.Fakes;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;
using TtopAcademy.API.Models;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass] 
    public class TopicsControllerTest
    {
        private TopicsController topicsController;
        private List<CategorySubjectTopic> testCategorySubjectTopics;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            testCategorySubjectTopics = GetTestCegorySubjectTopics();
            ITopicManager fakeTopicManager = new FakeTopicManager(testCategorySubjectTopics);
            topicsController = new TopicsController(fakeTopicManager);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testCategorySubjectTopics = null;
            topicsController = null;
        }

        [TestMethod]
        public async Task Get_ShouldReturnAll()
        {
            var result = await topicsController.Get() as IEnumerable<Topic>;
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task Get_ShouldReturnForCategoryAndSubjectID()
        {
            string concatenatedCategoryAndSubjectID = "1-1";
            var result = await topicsController.Get(concatenatedCategoryAndSubjectID);
            Assert.AreEqual(2, result.Count()); 
        }

        [TestMethod]
        public async Task Post_ShouldReturnPostedEntry()
        {
            TopicBindingModel model = new TopicBindingModel
            {
                CategoryID = 1, SubjectID = 1, 
                Number = 3, Name = "Geometry" 
            };
            var result = await topicsController.Post(model) as OkNegotiatedContentResult<Topic>;

            Assert.IsNotNull(result);
            Assert.AreEqual(model.Name, result.Content.Name);
        }

        [TestMethod]
        public async Task Put_ShouldReturnOk()
        {
            TopicBindingModel model = new TopicBindingModel { 
                TopicID = 2, CategoryID = 1, SubjectID = 1, Number = 2, Name = "Set Theory" };
            IHttpActionResult actionResult = await topicsController.Put(1, model);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public async Task Delete_ShouldReturnOk()
        {
            IHttpActionResult actionResult = await topicsController.Delete("1-1-1");

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }


        private List<CategorySubjectTopic> GetTestCegorySubjectTopics() 
        {
            var testCategorySubjectTopics = new List<CategorySubjectTopic>
            {
                new CategorySubjectTopic { 
                    CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                    CategorySubject = new CategorySubject { 
                        CategorySubjectID = 1, CategoryID = 1, SubjectID = 1
                    },
                    Topic = new Topic { TopicID = 1, Number = 1, Name = "Calculus"  }
                },
                new CategorySubjectTopic { 
                    CategorySubjectTopicID = 2, CategorySubjectID = 1, TopicID = 2,
                    CategorySubject = new CategorySubject { 
                        CategorySubjectID = 1, CategoryID = 1, SubjectID = 1
                    },
                    Topic = new Topic { TopicID = 2, Number = 2, Name = "Set" }
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
