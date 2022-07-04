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
    public class SubjectRepositoryTest
    {
        ISubjectRepository subjectRepository;
        IApplicationDbContext applicationDbContext;
        Subject dbEntry;

        [TestInitialize]
        public async Task InitializeBeforeEachTest()
        {
            applicationDbContext = new FakeApplicationDbContext();
            subjectRepository = new SubjectRepository(applicationDbContext);

            // PreSave
            Subject category = new Subject { Number = 1, Name = "English" };
            dbEntry = await subjectRepository.SaveSubjectAsync(category);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            subjectRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAll()  
        {
            IEnumerable<Subject> results = await subjectRepository.GetAllSubjectsAsync();

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public async Task SaveCategoryAsync_ShouldReturnSavedEntry()
        {
            Subject subject = new Subject { Number = 2, Name = "Physics" };
            var result = await subjectRepository.SaveSubjectAsync(subject);

            Assert.AreEqual(subject.Number, result.Number);
            Assert.AreEqual(subject.Name, result.Name);
        }

        [TestMethod]
        public async Task UpdateSubjectAsync_ShouldReturnEditedEntry() 
        {
            Subject subject = new Subject { SubjectID = dbEntry.SubjectID, Number = 1, Name = "USe of English" };
            Subject result = await subjectRepository.UpdateSubjectAsync(subject);

            Assert.AreEqual(subject.Number, result.Number);
            Assert.AreEqual(subject.Name, result.Name);
        }

        [TestMethod]
        public async Task DeleteSubjectAsync_ShouldReturnDeletedSubject() 
        {
            Subject result = await subjectRepository.DeleteSubjectAsync(dbEntry.SubjectID);

            Assert.AreEqual(dbEntry.Number, result.Number);
            Assert.AreEqual(dbEntry.Name, result.Name);
        }
    }
}
