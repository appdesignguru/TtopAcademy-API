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
    public class ChemistryPracticeQuestionRepository : IPracticeQuestionRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        public ChemistryPracticeQuestionRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(int videoID)
        {
            return await Task.FromResult(context.ChemistryPracticeQuestions.Where(c => c.VideoID == videoID)); 
        }

        public async Task<PracticeQuestion> DeletePracticeQuestionAsync(int PracticeQuestionID)
        {
            ChemistryPracticeQuestion dbEntry = await context.ChemistryPracticeQuestions.FindAsync(PracticeQuestionID);
            if (dbEntry != null)
            {
                context.ChemistryPracticeQuestions.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<PracticeQuestion> SavePracticeQuestionAsync(PracticeQuestion practiceQuestion)
        {
            ChemistryPracticeQuestion chemistryPracticeQuestion = new ChemistryPracticeQuestion
            {
                PracticeQuestionID = practiceQuestion.PracticeQuestionID,
                VideoID = practiceQuestion.VideoID,
                QuestionNumber = practiceQuestion.QuestionNumber,
                Question = practiceQuestion.Question,
                OptionA = practiceQuestion.OptionA,
                OptionB = practiceQuestion.OptionB,
                OptionC = practiceQuestion.OptionC,
                OptionD = practiceQuestion.OptionD,
                CorrectOption = practiceQuestion.CorrectOption
            };
            context.ChemistryPracticeQuestions.Add(chemistryPracticeQuestion); 
            await context.SaveChangesAsync();
            practiceQuestion = GetPracticeQuestionDbEntry(practiceQuestion);

            return practiceQuestion;
        }
         
        public async Task<PracticeQuestion> UpdatePracticeQuestionAsync(PracticeQuestion practiceQuestion)
        {
            PracticeQuestion dbEntry = await context.ChemistryPracticeQuestions.FindAsync(practiceQuestion.PracticeQuestionID);
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
            return context.ChemistryPracticeQuestions.FirstOrDefault(p => p.Question == practiceQuestion.Question);
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