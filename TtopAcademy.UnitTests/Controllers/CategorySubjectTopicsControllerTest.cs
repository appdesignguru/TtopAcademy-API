using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass]
    public class CategorySubjectTopicsControllerTest
    {
        [TestMethod]
        public async Task Get_ShouldReturnAll()
        {
            List<CategorySubjectTopic> testCategorySubjectTopics = GetTestCategorySubjectTopics();
            ICategorySubjectTopicRepository fakeCategorySubjectTopicRepository = new FakeCategorySubjectTopicRepository(testCategorySubjectTopics);
            CategorySubjectTopicsController categorySubjectTopicsController = new CategorySubjectTopicsController(fakeCategorySubjectTopicRepository);

            var result = await categorySubjectTopicsController.Get() as IEnumerable<CategorySubjectTopic>;
            Assert.AreEqual(testCategorySubjectTopics.Count(), result.Count()); 
        }

        private List<CategorySubjectTopic> GetTestCategorySubjectTopics()
        {
            var testCategorySubjectTopics = new List<CategorySubjectTopic> {
                new CategorySubjectTopic { CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1 },
                new CategorySubjectTopic { CategorySubjectTopicID = 2, CategorySubjectID = 1, TopicID = 2 },
            };
            return testCategorySubjectTopics;
        }
    }
}
