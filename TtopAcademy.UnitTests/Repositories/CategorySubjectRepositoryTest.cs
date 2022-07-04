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
    public class CategorySubjectRepositoryTest
    { 
        ICategorySubjectRepository categorySubjectRepository;
        IApplicationDbContext applicationDbContext;
        CategorySubject dbEntry;

        [TestInitialize]
        public async Task InitializeBeforeEachTest()
        {
            applicationDbContext = new FakeApplicationDbContext();
            categorySubjectRepository = new CategorySubjectRepository(applicationDbContext);

            //PreSave
            CategorySubject categorySubject = new CategorySubject
            {
                CategoryID = 1,
                SubjectID = 1
            };
            dbEntry = await categorySubjectRepository.SaveCategorySubjectAsync(categorySubject);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            categorySubjectRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            IEnumerable<CategorySubject> results = await categorySubjectRepository.GetAllCategorySubjectsAsync();

            Assert.AreEqual(1, results.Count());
        } 

        [TestMethod]
        public async Task GetCategorySubjectsAsync_ShouldReturnForCategoryID()
        {
            int categoryID = 1;
            IEnumerable<CategorySubject> results = 
                await categorySubjectRepository.GetCategorySubjectsAsync(categoryID);

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public async Task GetCategorySubjectAsync_ShouldReturnForCategoryIDAndSubjectID()
        {
            int categoryID = 1;
            int subjectID = 1;
            CategorySubject result = 
                await categorySubjectRepository.GetCategorySubjectAsync(categoryID, subjectID);

            Assert.AreEqual(dbEntry.CategorySubjectID, result.CategorySubjectID);
        }

        [TestMethod]
        public async Task GetCategorySubjectIDAsync_ShouldReturnForCategoryIDAndSubjectID()
        {
            int categoryID = 1;
            int subjectID = 1; 
            int result = await categorySubjectRepository.GetCategorySubjectIDAsync(categoryID, subjectID);

            Assert.AreEqual(dbEntry.CategorySubjectID, result);
        }

        [TestMethod]
        public async Task SaveCategoryAsync_ShouldReturnSavedEntry()
        {
            CategorySubject categorySubject = new CategorySubject { CategoryID = 1, SubjectID = 2 };
            var result = await categorySubjectRepository.SaveCategorySubjectAsync(categorySubject);

            Assert.AreEqual(categorySubject.CategoryID, result.CategoryID);
            Assert.AreEqual(categorySubject.SubjectID, result.SubjectID);
        }

        [TestMethod]
        public async Task DeleteCategoryAsync_ShouldReturnDeletedObject()
        {
            CategorySubject result = await categorySubjectRepository.DeleleteCategorySubjectAsync(1, 1);

            Assert.AreEqual(dbEntry.CategoryID, result.CategoryID);
            Assert.AreEqual(dbEntry.SubjectID, result.SubjectID);
        }
    } 
}
