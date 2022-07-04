using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.ApplicationCore.Managers  
{
    /// <summary> Interface  for managing practice questions. </summary>
    public interface IPracticeQuestionManager
    {
        /// <summary> Returns practice questions for given parameters. </summary>
        Task<IEnumerable<PracticeQuestion>> GetPracticeQuestionsAsync(string subjectName, int videoID);

        /// <summary> Returns saved practice question or null if saving not successful. </summary>
        Task<PracticeQuestion> SavePracticeQuestionAsync(string subjectName, PracticeQuestion practiceQuestion);

        /// <summary> Returns updated practice question or null if the practicequestion
        ///     to be updated does not exist. </summary> 
        Task<PracticeQuestion> UpdatePracticeQuestionAsync(string subjectName, PracticeQuestion practiceQuestion);

        /// <summary> Returns deleted practice question or null if the practicequestion
        ///     to be deleted does not exist. </summary> 
        Task<PracticeQuestion> DeletePracticeQuestionAsync(string subjectName, int practiceQuestionID);
    }
}
