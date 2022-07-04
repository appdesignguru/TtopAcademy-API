using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Factories;
using TtopAcademy.API.Infrastructure.Factories.Fakes;
using TtopAcademy.API.Infrastructure.Managers.Real;

namespace TtopAcademy.UnitTests.Managers
{
    [TestClass] 
    public class PracticeQuestionManagerTest
    {
        private PracticeQuestionManager practiceQuestionManager;
        private IPracticeQuestionFactory fakePracticeQuestionFactory;
        private List<PracticeQuestion> testPracticeQuestions;

        [TestInitialize]
        public void InitializeBeforeEachTest() 
        {
            testPracticeQuestions = GetPracticeQuestions();
            fakePracticeQuestionFactory = new FakePracticeQuestionFactory(testPracticeQuestions);
            practiceQuestionManager = new PracticeQuestionManager(fakePracticeQuestionFactory);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            practiceQuestionManager = null;
            fakePracticeQuestionFactory = null;
            testPracticeQuestions = null;
        }

        [TestMethod]
        public async Task GetPracticeQuestionsAsync_ShouldReturnForSubjectNameAndVideoID()
        {
            string subjectName = "Physics";
            int videoID = 1;
            var result = await practiceQuestionManager.GetPracticeQuestionsAsync(subjectName, videoID);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task SavePracticeQuestionsAsync_ShouldReturnPostedEntry()
        {
            string subjectName = "Physics"; 
            PracticeQuestion practiceQuestion = new PracticeQuestion { 
                PracticeQuestionID = 2, VideoID = 1 
            };
            var result = await practiceQuestionManager.SavePracticeQuestionAsync(subjectName, practiceQuestion);

            Assert.IsNotNull(result);
            Assert.AreEqual(practiceQuestion.PracticeQuestionID, result.PracticeQuestionID);
        }

        [TestMethod]
        public async Task UpdatePracticeQuestionsAsync_ShouldUpdatedPostedEntry()
        {  
            string subjectName = "Physics";
            PracticeQuestion practiceQuestion = new PracticeQuestion
            {
                PracticeQuestionID = 1,
                VideoID = 1, Question = "What is your name?"
            };
            var result = await practiceQuestionManager.UpdatePracticeQuestionAsync(subjectName, practiceQuestion);

            Assert.IsNotNull(result);
        } 

        [TestMethod]
        public async Task DeletePracticeQuestionsAsync_ShouldReturnDeletedEntry()
        {
            string subjectName = "Physics";
            int practiceQuestionID = 1;
            var result = await practiceQuestionManager.DeletePracticeQuestionAsync(subjectName, practiceQuestionID);

            Assert.IsNotNull(result);
        }

        private List<PracticeQuestion> GetPracticeQuestions()
        {
            List<PracticeQuestion> testPracticeQuestions = new List<PracticeQuestion> { 
                new PracticeQuestion
                {
                    PracticeQuestionID = 1, VideoID = 1
                }
            };
            return testPracticeQuestions;
        }

    }
}
