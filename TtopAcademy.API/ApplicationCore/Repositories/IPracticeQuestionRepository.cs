using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> PracticeQuestionRepository repository interface. </summary>
    public interface IPracticeQuestionRepository
    {
        /// <summary> Returns all practice questions for given parameter. </summary>
        Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(int videoID);

        /// <summary> Returns saved practice question or null if saving not successful. </summary>
        Task<PracticeQuestion> SavePracticeQuestionAsync(PracticeQuestion practiceQuestion);

        /// <summary> Returns updated practice question  or null if the practice question
        ///     to be deleted does not exist. </summary> 
        Task<PracticeQuestion> UpdatePracticeQuestionAsync(PracticeQuestion practiceQuestion);

        /// <summary> Returns deleted practice question  or null if the practice question
        ///     to be deleted does not exist. </summary> 
        Task<PracticeQuestion> DeletePracticeQuestionAsync(int practiceQuestionID);
    }
}
