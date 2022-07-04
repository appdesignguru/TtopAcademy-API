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
    public class CategorySubjectsControllerTest
    {
        [TestMethod]
        public async Task Get_ShouldReturnAll()
        {
            List<CategorySubject> testCategorySubjects = GetTestCategorySubjects();
            ICategorySubjectRepository fakeCategorySubjectRepository = new FakeCategorySubjectRepository(testCategorySubjects);
            CategorySubjectsController categorySubjectsController = new CategorySubjectsController(fakeCategorySubjectRepository);

            var result = await categorySubjectsController.Get() as IEnumerable<CategorySubject>; 
            Assert.AreEqual(testCategorySubjects.Count(), result.Count());
        }

        private List<CategorySubject> GetTestCategorySubjects()
        {
            var testCategorySubjects = new List<CategorySubject> { 
                new CategorySubject { CategorySubjectID = 1, CategoryID = 1, SubjectID = 1 },
                new CategorySubject { CategorySubjectID = 2, CategoryID = 1, SubjectID = 2 },
            };
            return testCategorySubjects;
        }
    }
}
