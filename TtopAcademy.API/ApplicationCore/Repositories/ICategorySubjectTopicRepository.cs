using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> CategorySubjectTopic repository interface. </summary>
    public interface ICategorySubjectTopicRepository
    {
        /// <summary> Returns all CategorySubjectTopics. </summary>
        Task<IEnumerable<CategorySubjectTopic>> GetAllCategorySubjectTopicsAsync(); 

        /// <summary> Returns all CategorySubjectTopics for given parameters. </summary>
        Task<IEnumerable<CategorySubjectTopic>> GetCategorySubjectTopicsAsync(int categoryID, int subjectID);

        /// <summary> Returns CategorySubjectTopic for given parameters or null if it doesn't exist. </summary> 
        Task<CategorySubjectTopic> GetCategorySubjectTopicAsync(int categoryID, int subjectID, int topicID);

        /// <summary> Returns CategorySubjectTopicID for given parameters. </summary> 
        Task<int> GetCategorySubjectTopicIDAsync(int categorySubjectID, int topicID);

        /// <summary> Returns saved CategorySubjectTopic or null if saving not successful. </summary>
        Task<CategorySubjectTopic> SaveCategorySubjectTopicAsync(CategorySubjectTopic categorySubjectTopic);

        /// <summary> Returns deleted CategorySubjectTopic or null if the CategorySubjectTopic
        ///     to be deleted does not exist. </summary> 
        Task<CategorySubjectTopic> DeleteCategorySubjectTopicAsync(int categoryID, int subjectID, int topicID); 
    }
}
 