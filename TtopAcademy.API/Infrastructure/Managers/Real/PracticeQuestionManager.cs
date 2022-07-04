using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Factories;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Managers.Real  
{
    /// <summary> Class for managing practice questions. </summary>
    public class PracticeQuestionManager : IPracticeQuestionManager
    {
        private readonly IPracticeQuestionFactory practiceQuestionFactory;

        /// <summary> Constructs a new practice question managger with given parameter. </summary>
        public PracticeQuestionManager(IPracticeQuestionFactory practiceQuestionFactory)
        {
            this.practiceQuestionFactory = practiceQuestionFactory;
        }

        public async Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(string subjectName, int videoID)
        {   
            return await GetPracticeQuestionRepository(subjectName).GetPracticeQuestionsAsync(videoID);
        }

        public async Task<PracticeQuestion> DeletePracticeQuestionAsync(string subjectName, int practiceQuestionID)
        {            
            return await GetPracticeQuestionRepository(subjectName).DeletePracticeQuestionAsync(practiceQuestionID);
        }

        public async Task<PracticeQuestion> SavePracticeQuestionAsync(string subjectName, PracticeQuestion practiceQuestion)
        {
            return await GetPracticeQuestionRepository(subjectName).SavePracticeQuestionAsync(practiceQuestion);
        }

        public async Task<PracticeQuestion> UpdatePracticeQuestionAsync(string subjectName, PracticeQuestion practiceQuestion)
        {
            return await GetPracticeQuestionRepository(subjectName).UpdatePracticeQuestionAsync(practiceQuestion);
        }

        private IPracticeQuestionRepository GetPracticeQuestionRepository(string subjectName)
        {
            return practiceQuestionFactory.CreatePracticeQuestionRepository(subjectName);
        }
    }
}