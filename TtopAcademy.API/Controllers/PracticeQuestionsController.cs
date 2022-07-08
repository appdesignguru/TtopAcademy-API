using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.Models;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for practice questions. </summary>
    [Authorize(Roles = "Adminstrator")] 
    public class PracticeQuestionsController : ApiController
    {
        private readonly IPracticeQuestionManager practiceQuestionManager;

        /// <summary> Constructs a new practice question controller with given parameter. </summary>
        public PracticeQuestionsController(IPracticeQuestionManager practiceQuestionManager)
        {
            this.practiceQuestionManager = practiceQuestionManager;
        }

        /// <summary> Returns all practice questions with the given parameters in the
        ///     concatenated string id. Route is 
        ///     GET: api/api/PracticeQuestions/concatenatedSubjectNameAndVideoID </summary> 
        [AllowAnonymous] 
        public async Task<IEnumerable<PracticeQuestion>> Get(string id)
        {
            string[] ids = id.Split('-');

            string subjectName = ids[0];
            int videoID = int.Parse(ids[1]);

            return await practiceQuestionManager.GetPracticeQuestionsAsync(subjectName, videoID);
        }

        /// <summary> Saves the given data model. 
        ///     Route is POST: api/PracticeQuestions. </summary> 
        public async Task<IHttpActionResult> Post(PracticeQuestionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PracticeQuestion practiceQuestion = 
                await practiceQuestionManager.SavePracticeQuestionAsync(model.SubjectName, new PracticeQuestion
            {
                VideoID = model.VideoID,
                QuestionNumber = model.QuestionNumber,
                Question = model.Question,
                OptionA = model.OptionA,
                OptionB = model.OptionB,
                OptionC = model.OptionC,
                OptionD = model.OptionD,
                CorrectOption = model.CorrectOption
            });

            return Ok(practiceQuestion);
        }

        /// <summary> Updates the given data model with the specified practiceQuestionID. 
        ///     Route is PUT: api/PracticeQuestions/PracticeQuestionID. </summary> 
        public async Task<IHttpActionResult> Put(int id, PracticeQuestionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await practiceQuestionManager.UpdatePracticeQuestionAsync(model.SubjectName, new PracticeQuestion
            {
                PracticeQuestionID = id,
                VideoID = model.VideoID,
                QuestionNumber = model.QuestionNumber,
                Question = model.Question,
                OptionA = model.OptionA,
                OptionB = model.OptionB,
                OptionC = model.OptionC,
                OptionD = model.OptionD,
                CorrectOption = model.CorrectOption
            });
            return Ok(); 
        }

        /// <summary> Deletes the category with given parameters in the concatenated string id parameter. Route is
        ///     DELETE: api/PracticeQuestions/hyphenConcatenatedSubjectNameAndPracticeQuestionID </summary>  
        public async Task<IHttpActionResult> Delete(string id)
        {
            string[] queryParams = id.Split('-');
            string subjectName = queryParams[0];
            int practiceQuestionID = int.Parse(queryParams[1]);
            PracticeQuestion practiceQuestion = await practiceQuestionManager.DeletePracticeQuestionAsync(subjectName, practiceQuestionID);
            if (practiceQuestion == null)
            {
                return BadRequest("The Practice Question ID is invalid");
            }
            return Ok();
        }
    }
}
