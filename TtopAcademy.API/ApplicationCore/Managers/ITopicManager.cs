using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Managers
{
    /// <summary> Interface  for managing topics. </summary>
    public interface ITopicManager
    {
        /// <summary> Returns all topics. </summary>
        Task<IEnumerable<Topic>> GetAllTopicsAsync(); 

        /// <summary> Returns topics for given parameters. </summary>
        Task<IEnumerable<Topic>> GetTopicsAsync(int categoryID, int subjectID);

        /// <summary> Returns saved topic or null if saving not successful. </summary>
        Task<Topic> SaveTopicAsync(int categoryID, int subjectID, Topic topic);

        /// <summary> Returns updated topic or null if the topic
        ///     to be updated does not exist. </summary> 
        Task<Topic> UpdateTopicAsync(Topic topic);

        /// <summary> Returns deleted topic or null if the topic
        ///     to be deleted does not exist. </summary> 
        Task<Topic> DeleteTopicAsync(int topicID, int subjectID, int categoryID);
    }
}  
