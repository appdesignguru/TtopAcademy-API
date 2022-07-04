using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> CategorySubject repository interface. </summary>
    public interface ICategorySubjectTopicVideoRepository
    {
        /// <summary> Returns all CategorySubjectTopicVideos. </summary>
        Task<IEnumerable<CategorySubjectTopicVideo>> GetAllAsync();

        /// <summary> Returns all CategorySubjectTopicVideos for given parameters. </summary> 
        Task<IEnumerable<CategorySubjectTopicVideo>> GetCategorySubjectTopicVideosAsync(int categoryID, int subjectID, int topicID);

        /// <summary> Returns all CategorySubjectTopicVideos for given parameter. </summary> 
        Task<IEnumerable<CategorySubjectTopicVideo>> GetCategorySubjectTopicVideosAsync(int categorySubjectTopicID);

        /// <summary> Returns CategorySubjectTopicVideo for given parameters or null if it doesn't exist. </summary> 
        Task<CategorySubjectTopicVideo> GetCategorySubjectTopicVideoAsync(int categoryID, int subjectID, int topicID, int videoID);

        /// <summary> Returns saved CategorySubjectTopicVideo or null if saving not successful. </summary>
        Task<CategorySubjectTopicVideo> SaveCategorySubjectTopicVideoAsync(CategorySubjectTopicVideo categorySubjectTopicVideo);

        /// <summary> Returns deleted CategorySubjectTopicVideo or null if the CategorySubjectTopicVideo
        ///     to be deleted does not exist. </summary> 
        Task<CategorySubjectTopicVideo> DeleteCategorySubjectTopicVideoAsync(int categoryID, int subjectID, int topicID, int videoID);  
    }
}
