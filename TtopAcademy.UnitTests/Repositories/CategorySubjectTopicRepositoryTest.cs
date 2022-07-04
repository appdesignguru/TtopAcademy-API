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
    public class CategorySubjectTopicRepositoryTest
    {
        ICategorySubjectTopicRepository categorySubjectTopicRepository;
        IApplicationDbContext applicationDbContext;
        CategorySubjectTopic dbEntry; 

        [TestInitialize]
        public async Task InitializeBeforeEachTest() 
        {
            applicationDbContext = new FakeApplicationDbContext();
            categorySubjectTopicRepository = new CategorySubjectTopicRepository(applicationDbContext);

            //PreSave
            CategorySubjectTopic categorySubjectTopic = new CategorySubjectTopic
            {
                CategorySubjectID = 1,
                TopicID = 1,
                CategorySubject = new CategorySubject
                {
                    CategorySubjectID = 1,
                    CategoryID = 1,
                    SubjectID = 1
                }
            };
            dbEntry = await categorySubjectTopicRepository.SaveCategorySubjectTopicAsync(categorySubjectTopic);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            categorySubjectTopicRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            IEnumerable<CategorySubjectTopic> results = await categorySubjectTopicRepository.GetAllCategorySubjectTopicsAsync();

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public async Task GetCategorySubjectTopicsAsync_ShouldReturnForCategorySubjectID()
        {
            IEnumerable<CategorySubjectTopic> result =
                await categorySubjectTopicRepository.GetCategorySubjectTopicsAsync(1,1);

            Assert.AreEqual(1, result.Count()); 
        }

        [TestMethod]
        public async Task GetCategorySubjectTopicAsync_ShouldReturnSingleEntry()
        {
            CategorySubjectTopic result = 
                await categorySubjectTopicRepository.GetCategorySubjectTopicAsync(1, 1, 1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetCategorySubjectTopicIDAsync_ShouldReturnID()
        {
            int result = await categorySubjectTopicRepository.GetCategorySubjectTopicIDAsync(1, 1);

            Assert.AreEqual(dbEntry.CategorySubjectTopicID, result);
        }

        [TestMethod] 
        public async Task DeleteCategorySubjectTopicAsync_ShouldReturnDeletedEntry() 
        {
            CategorySubjectTopic result =
                await categorySubjectTopicRepository.DeleteCategorySubjectTopicAsync(1,1,1);

            Assert.AreEqual(dbEntry.TopicID, result.TopicID);
        }

        [TestMethod]
        public async Task SaveCategorySubjectTopicAsync_ShouldReturnSavedEntry()
        {
            CategorySubjectTopic categorySubjectTopic =
                new CategorySubjectTopic { CategorySubjectID = 1, TopicID = 2 };
            var result = await categorySubjectTopicRepository.SaveCategorySubjectTopicAsync(categorySubjectTopic);

            Assert.AreEqual(categorySubjectTopic.CategorySubjectID, result.CategorySubjectID);
            Assert.AreEqual(categorySubjectTopic.TopicID, result.TopicID);
        }
    }
}
