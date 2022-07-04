using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.Managers.Real;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;

namespace TtopAcademy.UnitTests.Managers
{
    [TestClass]
    public class SubjectManagerTest
    {
        private ISubjectManager subjectManager;
        private List<CategorySubject> testCategorySubjects;
        private List<Subject> testSubjects;

        [TestInitialize]
        public void InitializeBeforeEachTest() 
        {
            testCategorySubjects = GetTestCategorySubjects();
            testSubjects = GetTestSubjects();
            ICategorySubjectRepository fakeCategorySubjectRepository = new FakeCategorySubjectRepository(testCategorySubjects);
            ISubjectRepository fakeSubjectRepository = new FakeSubjectRepository(testSubjects);
            subjectManager = new SubjectManager(fakeSubjectRepository, fakeCategorySubjectRepository);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testSubjects = null;
            testCategorySubjects = null;
            subjectManager = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            IEnumerable<Subject> result = await subjectManager.GetAllSubjectsAsync(); 
            Assert.AreEqual(testSubjects.Count(), result.Count());
        }
         
        [TestMethod]
        public async Task GetSubjectsAsync_ShouldReturnSubjectsByCategoryID() 
        {
            int categoryID = 1;
            IEnumerable<Subject> result = await subjectManager.GetSubjectsAsync(categoryID);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task SaveSubjectAsync_ShouldReturnSavedEntry() 
        {
            int categoryID = 1;
            Subject subject = new Subject { Number = 3, Name = "Mathematics" };
            Subject result = await subjectManager.SaveSubjectAsync(categoryID, subject);

            Assert.IsNotNull(result);
            Assert.AreEqual(subject.Number, result.Number);
            Assert.AreEqual(subject.Name, result.Name);
        }

        [TestMethod]
        public async Task UpdateSubjectAsync_ShouldReturnUpdatedEntry() 
        {
            Subject subject = new Subject {SubjectID = 1, Number = 1, Name = "Use of English" };
            Subject result = await subjectManager.UpdateSubjectAsync(subject);

            Assert.IsNotNull(result);
            Assert.AreEqual(subject.Number, result.Number);
            Assert.AreEqual(subject.Name, result.Name);
        }

        [TestMethod]
        public async Task DeleteSubjectAsync_ShouldReturnDeletedEntry()
        {
            Subject result = await subjectManager.DeleteSubjectAsync(1, 1);

            Assert.IsNotNull(result);
        }

        private List<CategorySubject> GetTestCategorySubjects()
        {
            var testCategorySubjects = new List<CategorySubject> {
                new CategorySubject { CategorySubjectID = 1, CategoryID = 1, SubjectID = 1},
                new CategorySubject { CategorySubjectID = 2, CategoryID = 1, SubjectID = 2},
            };
            return testCategorySubjects;
        }

        private List<Subject> GetTestSubjects()
        {
            var testSubjects = new List<Subject> {
                new Subject { SubjectID = 1, Number = 1, Name = "English" },
                new Subject { SubjectID = 2,Number = 2, Name = "Physics" }
            };
            return testSubjects;
        }
    }
}
