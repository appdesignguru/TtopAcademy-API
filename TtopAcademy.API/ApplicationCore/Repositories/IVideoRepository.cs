using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> Video repository interface. </summary>
    public interface IVideoRepository
    {
        /// <summary> Returns all videos. </summary>
        Task<IEnumerable<Video>> GetAllVideosAsync();

        /// <summary> Returns saved video or null if saving not successful. </summary>
        Task<Video> SaveVideoAsync(Video video);

        /// <summary> Returns updated video or null if the video
        ///     to be updated does not exist. </summary> 
        Task<Video> UpdateVideoAsync(Video video);

        /// <summary> Returns deleted video or null if the video
        ///     to be deleted does not exist. </summary> 
        Task<Video> DeleteVideoAsync(int videoID);
    }
}
