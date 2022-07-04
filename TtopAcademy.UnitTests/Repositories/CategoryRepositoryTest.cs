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
    public class CategoryRepositoryTest
    {
        ICategoryRepository categoryRepository;
        IApplicationDbContext applicationDbContext;
        Category dbEntry; 

        [TestInitialize]
        public async Task InitializeBeforeEachTest()
        {
            applicationDbContext = new FakeApplicationDbContext();
            categoryRepository = new CategoryRepository(applicationDbContext);

            // PreSave
            Category category = new Category { Number = 1, Name = "JAMB" };
            dbEntry = await categoryRepository.SaveCategoryAsync(category);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            categoryRepository = null;
            dbEntry = null;
        }

        [TestMethod] 
        public async Task GetAllAsync_ShouldReturnAll()   
        {
            IEnumerable<Category> results = await categoryRepository.GetAllCategoriesAsync();

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public async Task SaveCategoryAsync_ShouldReturnSavedEntry()
        {
            Category category = new Category { Number = 2, Name = "SS3" };
            var result = await categoryRepository.SaveCategoryAsync(category);

            Assert.AreEqual(category.Number, result.Number); 
            Assert.AreEqual(category.Name, result.Name); 
        }

        [TestMethod]
        public async Task UpdateCategoryAsync_ShouldReturnEditedEntry()    
        {
            Category category = new Category {CategoryID = dbEntry.CategoryID, Number = 1, Name = "WAEC" };
            Category result = await categoryRepository.UpdateCategoryAsync(category);

            Assert.AreEqual(category.Number, result.Number);
            Assert.AreEqual(category.Name, result.Name); 
        } 

        [TestMethod]
        public async Task DeleteCategoryAsync_ShouldReturnDeletedSubject()  
        {
            Category result = await categoryRepository.DeleteCategoryAsync(dbEntry.CategoryID); 

            Assert.AreEqual(dbEntry.Number, result.Number); 
            Assert.AreEqual(dbEntry.Name, result.Name); 
        } 
    }
}
