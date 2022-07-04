using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for paginated videos. </summary>
    public class PaginatedVideosController : ApiController
    {
        private readonly IVideoRepository videoRepository;

        /// <summary> Constructs a new paginated videos controller with given parameter. </summary>
        public PaginatedVideosController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        /// <summary> Returns 100 videos whose videoID is greater than the specified
        /// id parameter. Route is GET: api/PaginatedVideos/VideoID </summary> 
        public async Task<IEnumerable<Video>> Get(int id)
        {
            return (await videoRepository.GetAllVideosAsync()).Where(p => p.VideoID > id).Take(100);
        }
    }
}
