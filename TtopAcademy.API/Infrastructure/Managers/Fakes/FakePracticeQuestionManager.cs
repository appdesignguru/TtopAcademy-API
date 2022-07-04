using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Managers;

namespace TtopAcademy.API.Infrastructure.Managers.Fakes
{
    public class FakePracticeQuestionManager : IPracticeQuestionManager
    {
        private readonly List<PracticeQuestion> practiceQuestions; 

        public FakePracticeQuestionManager(List<PracticeQuestion> practiceQuestions)
        {
            this.practiceQuestions = practiceQuestions;
        }

        public async Task<PracticeQuestion> DeletePracticeQuestionAsync(string subjectName, int practiceQuestionID)
        {
            PracticeQuestion practiceQuestion = practiceQuestions.FirstOrDefault(p => p.PracticeQuestionID == practiceQuestionID);
            if (practiceQuestion == null)
            {
                return null;
            }
            practiceQuestions.Remove(practiceQuestion);
            return await Task.FromResult(practiceQuestion);    
        }

        public async Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(string subjectName, int videoID)
        {
            return await Task.FromResult(practiceQuestions.Where(p => p.VideoID == videoID));
        }

        public async Task<PracticeQuestion> SavePracticeQuestionAsync(string subjectName, PracticeQuestion practiceQuestion)
        {
            practiceQuestions.Add(practiceQuestion);
            return await Task.FromResult(practiceQuestion);
        }

        public async Task<PracticeQuestion> UpdatePracticeQuestionAsync(string subjectName, PracticeQuestion practiceQuestion)
        {
            PracticeQuestion dbEntry = practiceQuestions.FirstOrDefault(
                p => p.PracticeQuestionID == practiceQuestion.PracticeQuestionID
            );
            if (practiceQuestion != null)
            {
                dbEntry.VideoID = practiceQuestion.VideoID;
                dbEntry.QuestionNumber = practiceQuestion.QuestionNumber;
                dbEntry.Question = practiceQuestion.Question;
                dbEntry.OptionA = practiceQuestion.OptionA;
                dbEntry.OptionB = practiceQuestion.OptionB;
                dbEntry.OptionC = practiceQuestion.OptionC;
                dbEntry.OptionD = practiceQuestion.OptionD;
                dbEntry.CorrectOption = practiceQuestion.CorrectOption;
            }
            return await Task.FromResult(dbEntry);
        }
    }
}