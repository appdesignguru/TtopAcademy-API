using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Managers.Fakes;
using TtopAcademy.API.Models;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass]
    public class PracticeQuestionsControllerTest
    {
        private PracticeQuestionsController practiceQuestionsController;
        private List<PracticeQuestion> testPracticeQuestions;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        { 
            testPracticeQuestions = GetTestPracticeQuestions();
            IPracticeQuestionManager fakePracticeQuestionManager = 
                new FakePracticeQuestionManager(testPracticeQuestions);
            practiceQuestionsController = 
                new PracticeQuestionsController(fakePracticeQuestionManager);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testPracticeQuestions = null;
            practiceQuestionsController = null;
        }

        [TestMethod] 
        public async Task Get_ShouldReturnForSubjectNameAndVideoID()
        {
            string hyphenConcatenatedSubjectNameAndVideoID = "physics-1";
            var result = 
                await practiceQuestionsController.Get(hyphenConcatenatedSubjectNameAndVideoID);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task Post_ShouldReturnPostedEntry()
        {
            PracticeQuestionBindingModel model = new PracticeQuestionBindingModel {
                VideoID = 1, QuestionNumber = 3,
                Question = "Who is the president of USA",
                OptionA = "Joe Biden", OptionB = "Barrack Obama",
                OptionC = "Donald Trump", OptionD = "Michael Onoja Jnr", 
                CorrectOption = Option.A
            };
            var result = await practiceQuestionsController.Post(model) as OkNegotiatedContentResult<PracticeQuestion>;

            Assert.IsNotNull(result);
            Assert.AreEqual(model.Question, result.Content.Question);
        }

        [TestMethod]
        public async Task Put_ShouldReturnOk()
        {
            PracticeQuestionBindingModel model = new PracticeQuestionBindingModel {
                PracticeQuestionID = 1, VideoID = 1, QuestionNumber = 1,
                Question = "What is the Capital of USA?",
                OptionA = "Texas, TX", OptionB = "Washinton DC",
                OptionC = "California", OptionD = "New York",
                CorrectOption = Option.B
            };
            IHttpActionResult actionResult = await practiceQuestionsController.Put(1, model);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public async Task Delete_ShouldReturnOk()
        {
            string subjectName = "Physics";
            int practiceQuestionID = 1; 
            string id = subjectName + "-" + practiceQuestionID; 
            IHttpActionResult actionResult = await practiceQuestionsController.Delete(id);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        private List<PracticeQuestion> GetTestPracticeQuestions()
        {
            var testPracticeQuestions = new List<PracticeQuestion> { 
                new PracticeQuestion {
                    PracticeQuestionID = 1, VideoID = 1, QuestionNumber = 1,
                    Question = "What is the Capital of USA?", OptionA = "Texas",
                    OptionB = "Washinton DC", OptionC = "California", 
                    OptionD = "New York", CorrectOption = Option.B
                },
                new PracticeQuestion{
                    PracticeQuestionID = 2, VideoID = 1, QuestionNumber = 2,
                    Question = "The most populus country in the world is ",
                    OptionA = "China", OptionB = "USA", OptionC = "Russia",
                    OptionD = "India", CorrectOption = Option.A
                }
            };
            return testPracticeQuestions;
        }
    }
}
