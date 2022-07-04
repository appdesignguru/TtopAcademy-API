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
using TutorField.API.Models;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass]
    public class SubjectsControllerTest
    {
        private SubjectsController subjectController;
        private List<CategorySubject> testCategorySubjects;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            testCategorySubjects = GetTestCategorySubjects();
            ISubjectManager fakeSubjectManager = new FakeSubjectManager(testCategorySubjects);
            subjectController = new SubjectsController(fakeSubjectManager);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testCategorySubjects = null;
            subjectController = null;
        }

        [TestMethod] 
        public async Task Get_ShouldReturnAll()
        {
            var result = await subjectController.Get() as IEnumerable<Subject>;
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task Get_ShouldReturnSubjectsByCategoryID() 
        {
            var result = await subjectController.Get(1) as IEnumerable<Subject>;
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task Post_ShouldReturnPostedEntry()
        {
            SubjectBindingModel model = new SubjectBindingModel { CategoryID = 1, Number = 3, Name = "Mathematics" };
            var result = await subjectController.Post(model) as OkNegotiatedContentResult<Subject>;

            Assert.IsNotNull(result);
            Assert.AreEqual(model.Name, result.Content.Name);
        }

        [TestMethod]
        public async Task Put_ShouldReturnOk()
        {
            SubjectBindingModel model = new SubjectBindingModel { SubjectID = 1, Number = 1, Name = "Use of English" };
            IHttpActionResult actionResult = await subjectController.Put(1, model);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public async Task Delete_ShouldReturnOk()
        {
            string id = "1-1";  // hyphenConcatenatedCategoryIDAndSubjectID
            IHttpActionResult actionResult = await subjectController.Delete(id);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        private List<CategorySubject> GetTestCategorySubjects()
        {
            var testCategorySubjects = new List<CategorySubject> {
                new CategorySubject { 
                    CategorySubjectID = 1, CategoryID = 1, SubjectID = 1,
                    Subject = new Subject { SubjectID = 1, Number = 1, Name = "English"  }
                },
                new CategorySubject { 
                    CategorySubjectID = 2, CategoryID = 1, SubjectID = 2,
                    Subject = new Subject { SubjectID = 2, Number = 2, Name = "Physics" }
                }
            };
            return testCategorySubjects;
        }
    }
}
