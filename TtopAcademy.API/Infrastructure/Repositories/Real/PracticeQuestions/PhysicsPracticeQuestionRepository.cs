using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Real.PracticeQuestions
{
    /// <summary> Physics practice question repository implementation class. </summary>
    public class PhysicsPracticeQuestionRepository : IPracticeQuestionRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new physics practice question repository with given parameter. </summary> 
        public PhysicsPracticeQuestionRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(int videoID)
        {
            return await Task.FromResult(context.PhysicsPracticeQuestions.Where(c => c.VideoID == videoID));
        } 

        public async Task<PracticeQuestion> DeletePracticeQuestionAsync(int practiceQuestionID)
        {
            PhysicsPracticeQuestion dbEntry = await context.PhysicsPracticeQuestions.FindAsync(practiceQuestionID);
            if (dbEntry != null)
            {
                context.PhysicsPracticeQuestions.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<PracticeQuestion> SavePracticeQuestionAsync(PracticeQuestion practiceQuestion)
        {
            PhysicsPracticeQuestion physicsPracticeQuestion = new PhysicsPracticeQuestion
            {
                PracticeQuestionID = practiceQuestion.PracticeQuestionID,
                VideoID = practiceQuestion.VideoID, QuestionNumber = practiceQuestion.QuestionNumber,
                Question = practiceQuestion.Question, OptionA = practiceQuestion.OptionA,
                OptionB = practiceQuestion.OptionB, OptionC = practiceQuestion.OptionC,
                OptionD = practiceQuestion.OptionD, CorrectOption = practiceQuestion.CorrectOption
            };
            context.PhysicsPracticeQuestions.Add(physicsPracticeQuestion); 
            await context.SaveChangesAsync();
            practiceQuestion = GetPracticeQuestionDbEntry(practiceQuestion);

            return practiceQuestion;
        }

        public async Task<PracticeQuestion> UpdatePracticeQuestionAsync(PracticeQuestion practiceQuestion)
        {
            PracticeQuestion dbEntry = await context.PhysicsPracticeQuestions.FindAsync(practiceQuestion.PracticeQuestionID);
            if (dbEntry != null)
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
            await context.SaveChangesAsync();
            return dbEntry;
        }

        private PracticeQuestion GetPracticeQuestionDbEntry(PracticeQuestion practiceQuestion)
        {
            return context.PhysicsPracticeQuestions.FirstOrDefault(p => p.Question == practiceQuestion.Question);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}