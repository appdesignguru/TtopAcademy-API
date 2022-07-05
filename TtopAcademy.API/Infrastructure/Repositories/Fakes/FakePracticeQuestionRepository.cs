using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    /// <summary> Fake practice question repository implemetation class. Used for unit testing. </summary>
    public class FakePracticeQuestionRepository : IPracticeQuestionRepository
    {
        private readonly List<PracticeQuestion> practiceQuestions;

        /// <summary> Constructs a new FakePracticeQuestionRepository with given parameter. </summary>
        public FakePracticeQuestionRepository(List<PracticeQuestion> practiceQuestions)
        {
            this.practiceQuestions = practiceQuestions;
        }

        public async Task<PracticeQuestion> DeletePracticeQuestionAsync(int practiceQuestionID)
        {
            return await Task.FromResult(DeletePracticeQuestion(practiceQuestionID));
        }

        public async Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(int videoID)
        {
            return await Task.FromResult(GetPracticeQuestions(videoID));
        }

        public async Task<PracticeQuestion> SavePracticeQuestionAsync(PracticeQuestion practiceQuestion)
        {
            return await Task.FromResult(SavePracticeQuestion(practiceQuestion));
        }

        public async Task<PracticeQuestion> UpdatePracticeQuestionAsync(PracticeQuestion practiceQuestion)
        {
            return await Task.FromResult(UpdatePracticeQuestion(practiceQuestion));
        }

        private PracticeQuestion DeletePracticeQuestion(int practiceQuestionID)
        {
            PracticeQuestion practiceQuestion =
                practiceQuestions.FirstOrDefault(p => p.PracticeQuestionID == practiceQuestionID);
            if (practiceQuestion != null)
            {
                practiceQuestions.Remove(practiceQuestion);
            }
            return practiceQuestion;
        }

        private IEnumerable<PracticeQuestion> GetPracticeQuestions(int videoID)
        {
            return practiceQuestions.Where(p => p.VideoID == videoID);
        }

        private PracticeQuestion SavePracticeQuestion(PracticeQuestion practiceQuestion)
        {
            practiceQuestion.PracticeQuestionID = 100;
            practiceQuestions.Add(practiceQuestion);
            return practiceQuestion;
        }

        private PracticeQuestion UpdatePracticeQuestion(PracticeQuestion practiceQuestion)
        {
            PracticeQuestion entry = practiceQuestions.FirstOrDefault(
                p => p.PracticeQuestionID == practiceQuestion.PracticeQuestionID
            );
            if (practiceQuestion != null)
            {
                entry.VideoID = practiceQuestion.VideoID;
                entry.QuestionNumber = practiceQuestion.QuestionNumber;
                entry.Question = practiceQuestion.Question;
                entry.OptionA = practiceQuestion.OptionA;
                entry.OptionB = practiceQuestion.OptionB;
                entry.OptionC = practiceQuestion.OptionC;
                entry.OptionD = practiceQuestion.OptionD;
                entry.CorrectOption = practiceQuestion.CorrectOption;
            }
            return entry;
        }
    }
}