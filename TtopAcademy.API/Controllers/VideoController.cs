using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for video. </summary>
    public class VideoController : ApiController
    {
        private readonly IVideoManager videoManager;

        /// <summary> Constructs a new video controller with given parameter. </summary>
        public VideoController(IVideoManager videoManager)
        {
            this.videoManager = videoManager;
        }

        /// <summary> Returns all videos for the given categorySubjectTopicID. 
        ///     Route is GET: api/Video/categorySubjectTopicID </summary> 
        public async Task<IEnumerable<Video>> Get(int id)
        {
            int categorySubjectTopicID = id;

            IEnumerable<Video> videos = await videoManager.GetVideosAsync(categorySubjectTopicID);

            return videos;
        }       
    }
}
