
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
    public class CategorySubjectTopicVideosControllerTest
    {
        private CategorySubjectTopicVideosController categorySubjectTopicVideosController;
        private List<CategorySubjectTopicVideo> testCategorySubjectTopicVideos; 

        [TestInitialize] 
        public void InitializeBeforeEachTest()
        {
            testCategorySubjectTopicVideos = GetTestCategorySubjectTopicVideos();
            ICategorySubjectTopicVideoRepository fakeCategorySubjectTopicRepository = new FakeCategorySubjectTopicVideoRepository(testCategorySubjectTopicVideos);
            categorySubjectTopicVideosController = new CategorySubjectTopicVideosController(fakeCategorySubjectTopicRepository);

        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testCategorySubjectTopicVideos = null;
            categorySubjectTopicVideosController = null;
        }

        [TestMethod]
        public async Task Get_ShouldReturnAll()
        { 
            var result = await categorySubjectTopicVideosController.Get(); 
            Assert.AreEqual(testCategorySubjectTopicVideos.Count(), result.Count());
        }

        [TestMethod]
        public async Task Get_ShouldReturnShouldReturnForCategorySubjectTopicID() 
        {
            int categorySubjectTopicID = 1;
            var result = await categorySubjectTopicVideosController.Get(categorySubjectTopicID);
            Assert.AreEqual(testCategorySubjectTopicVideos.Count(), result.Count());
        }

        private List<CategorySubjectTopicVideo> GetTestCategorySubjectTopicVideos()
        {
            var testCategorySubjectTopicVideos = new List<CategorySubjectTopicVideo> {
                new CategorySubjectTopicVideo { CategorySubjectTopicVideoID = 1, CategorySubjectTopicID = 1, VideoID = 1 },
                new CategorySubjectTopicVideo { CategorySubjectTopicVideoID = 2, CategorySubjectTopicID = 1, VideoID = 2 },
            };
            return testCategorySubjectTopicVideos;
        }
    }
}
