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
    public class CategorySubjectTopicVideoRepositoryTest
    {
        ICategorySubjectTopicVideoRepository categorySubjectTopicVideoRepository;
        IApplicationDbContext applicationDbContext;
        CategorySubjectTopicVideo dbEntry; 

        [TestInitialize]
        public async Task InitializeBeforeEachTest()
        {
            applicationDbContext = new FakeApplicationDbContext();
            categorySubjectTopicVideoRepository = new CategorySubjectTopicVideoRepository(applicationDbContext);

            //PreSave
            CategorySubjectTopicVideo categorySubjectTopic = new CategorySubjectTopicVideo
            {
                CategorySubjectTopicVideoID = 1,
                CategorySubjectTopicID = 1,
                VideoID = 1,
                CategorySubjectTopic = new CategorySubjectTopic
                {
                    CategorySubjectTopicID = 1,
                    CategorySubjectID = 1,
                    TopicID = 1,
                    CategorySubject = new CategorySubject
                    {
                        CategorySubjectID = 1,
                        CategoryID = 1,
                        SubjectID = 1
                    }
                }
            };
            dbEntry = await categorySubjectTopicVideoRepository.SaveCategorySubjectTopicVideoAsync(categorySubjectTopic);
        }

        [TestCleanup] 
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            categorySubjectTopicVideoRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            IEnumerable<CategorySubjectTopicVideo> results = await categorySubjectTopicVideoRepository.GetAllAsync();

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod] 
        public async Task GetCategorySubjectTopicVideosAsync_ShouldReturnForCategoryIDSubjectIDTopicID()
        {
            IEnumerable<CategorySubjectTopicVideo> result =
               await categorySubjectTopicVideoRepository.GetCategorySubjectTopicVideosAsync(1, 1, 1);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetCategorySubjectTopicVideosAsync_ShouldReturnForCategorySubjectTopicID()
        {
            int categorySubjectTopicID = 1; 
            IEnumerable<CategorySubjectTopicVideo> result =
               await categorySubjectTopicVideoRepository.GetCategorySubjectTopicVideosAsync(categorySubjectTopicID);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task GetCategorySubjectTopicVideoAsync_ShouldReturnSingleEntry()
        {
            CategorySubjectTopicVideo result =
                await categorySubjectTopicVideoRepository.GetCategorySubjectTopicVideoAsync(1, 1, 1, 1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteCategorySubjectTopicVideoAsync_ShouldReturnDeletedEntry()
        {
            CategorySubjectTopicVideo result =
               await categorySubjectTopicVideoRepository.DeleteCategorySubjectTopicVideoAsync(1, 1, 1, 1);

            Assert.AreEqual(dbEntry.VideoID, result.VideoID);
        }

        [TestMethod]
        public async Task SaveCategorySubjectTopicVideoAsync()
        {
            CategorySubjectTopicVideo categorySubjectTopicVideo =
                new CategorySubjectTopicVideo { CategorySubjectTopicID = 1, VideoID = 2 };
            var result = await categorySubjectTopicVideoRepository.SaveCategorySubjectTopicVideoAsync(categorySubjectTopicVideo);

            Assert.AreEqual(categorySubjectTopicVideo.CategorySubjectTopicID, result.CategorySubjectTopicID);
            Assert.AreEqual(categorySubjectTopicVideo.VideoID, result.VideoID);
        }
    }
}
