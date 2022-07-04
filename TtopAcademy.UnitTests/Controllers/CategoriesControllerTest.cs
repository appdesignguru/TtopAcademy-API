using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;
using TtopAcademy.API.ApplicationCore.Repositories;
using TutorField.API.Models;
using System.Web.Http;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass]
    public class CategoriesControllerTest
    {
        private CategoriesController categoriesController; 
        private List<Category> testCategories;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            testCategories = GetTestCategories();
            ICategoryRepository fakeCategoryRepository = new FakeCategoryRepository(testCategories);
            categoriesController = new CategoriesController(fakeCategoryRepository);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest()   
        {
            testCategories = null;
            categoriesController = null;
        }

        [TestMethod]
        public async Task Get_ShouldReturnAll()  
        {
            var result = await categoriesController.Get();
            Assert.AreEqual(testCategories.Count(), result.Count());
        }

        
        [TestMethod] 
        public async Task Post_ShouldReturnPostedEntry()
        {
            CategoryBindingModel model = new CategoryBindingModel { Number = 3, Name = "SS2" };
            var result = await categoriesController.Post(model) as OkNegotiatedContentResult<Category>;

            Assert.IsNotNull(result);
            Assert.AreEqual(model.Name, result.Content.Name);
        }

        [TestMethod]
        public async Task Put_ShouldReturnOk()
        {
            CategoryBindingModel model = new CategoryBindingModel { CategoryID = 2, Number = 2, Name = "SSS3" };
            IHttpActionResult actionResult = await categoriesController.Put(2, model);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public async Task Delete_ShouldReturnOk()
        {
            IHttpActionResult actionResult = await categoriesController.Delete(2);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        private List<Category> GetTestCategories()
        {
            var testCategories = new List<Category>
            {
                new Category { CategoryID = 1, Number = 1, Name = "JAMB" },
                new Category { CategoryID = 2, Number = 2, Name = "SS3" }
            };

            return testCategories;
        }
    }
}
