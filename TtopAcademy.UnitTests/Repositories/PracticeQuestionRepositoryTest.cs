using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.ApplicationDbContext.Fakes;
using TtopAcademy.API.Infrastructure.Repositories.Real.PracticeQuestions;

namespace TtopAcademy.UnitTests.Repositories
{
    [TestClass]  
    public class PracticeQuestionRepositoryTest
    {
        IPracticeQuestionRepository practiceQuestionRepository;
        IApplicationDbContext applicationDbContext;
        PracticeQuestion dbEntry; 

        [TestInitialize]
        public async Task InitializeBeforeEachTest()
        {
            applicationDbContext = new FakeApplicationDbContext();
            practiceQuestionRepository = new PhysicsPracticeQuestionRepository(applicationDbContext);

            // PreSave
            PracticeQuestion practiceQuestion = new PracticeQuestion {
                VideoID = 1, QuestionNumber = 2 
            };
            dbEntry = await practiceQuestionRepository.SavePracticeQuestionAsync(practiceQuestion);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            applicationDbContext.Dispose();
            applicationDbContext = null;
            practiceQuestionRepository = null;
            dbEntry = null;
        }

        [TestMethod]
        public async Task GetPracticeQuestionsAsync_ShouldReturnAll()
        {
            int videoID = 1;
            IEnumerable<PracticeQuestion> results = await practiceQuestionRepository.GetPracticeQuestionsAsync(videoID);

            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public async Task SavePracticeQuestionAsync_ShouldReturnSavedEntry()
        {
            PracticeQuestion practiceQuestion = new PracticeQuestion { 
                VideoID = 1, QuestionNumber = 2 
            };
            var result = await practiceQuestionRepository.SavePracticeQuestionAsync(practiceQuestion);

            Assert.AreEqual(practiceQuestion.VideoID, result.VideoID); 
        }

        [TestMethod]
        public async Task UpdatePracticeQuestionAsync_ShouldReturnEditedEntry() 
        {
            PracticeQuestion practiceQuestion = new PracticeQuestion {
                PracticeQuestionID = dbEntry.PracticeQuestionID, QuestionNumber = 5
            };
            PracticeQuestion result = await practiceQuestionRepository.UpdatePracticeQuestionAsync(practiceQuestion);

            Assert.AreEqual(practiceQuestion.QuestionNumber, result.QuestionNumber);
        }

        [TestMethod]
        public async Task DeleteCategoryAsync_ShouldReturnDeletedSubject()
        {
            PracticeQuestion result = await practiceQuestionRepository.DeletePracticeQuestionAsync(dbEntry.PracticeQuestionID);

            Assert.AreEqual(dbEntry.PracticeQuestionID, result.PracticeQuestionID);
        }
    }
}
