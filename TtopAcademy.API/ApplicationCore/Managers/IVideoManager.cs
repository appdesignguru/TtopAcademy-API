using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Managers
{
    /// <summary> Interface  for managing videos. </summary>
    public interface IVideoManager
    {
        /// <summary> Returns all videos. </summary>
        Task<IEnumerable<Video>> GetAllVideosAsync(); 

        /// <summary> Returns videos for given parameters. </summary>
        Task<IEnumerable<Video>> GetVideosAsync(int categoryID, int subjectID, int topicID);

        /// <summary> Returns videos for given parameter. </summary>
        Task<IEnumerable<Video>> GetVideosAsync(int categorySubjectTopicID);

        /// <summary> Returns saved video or null if saving not successful. </summary>
        Task<Video> SaveVideoAsync(int categoryID, int subjectID, int topicID, Video video);

        /// <summary> Returns updated video or null if the video
        ///     to be updated does not exist. </summary> 
        Task<Video> UpdateVideoAsync(Video video);

        /// <summary> Returns deleted video or null if the video
        ///     to be deleted does not exist. </summary> 
        Task<Video> DeleteVideoAsync(int videoID, int topicID, int subjectID, int categoryID); 
    }
}
