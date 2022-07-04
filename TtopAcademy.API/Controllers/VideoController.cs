using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Controllers
{
    public class VideoController : ApiController
    {
        private readonly IVideoManager videoManager;

        public VideoController(IVideoManager videoManager)
        {
            this.videoManager = videoManager;
        }

        // GET: api/Video/categorySubjectTopicID  
        public async Task<IEnumerable<Video>> Get(int id)
        {
            int categorySubjectTopicID = id;

            IEnumerable<Video> videos = await videoManager.GetVideosAsync(categorySubjectTopicID);

            return videos;
        }       
    }
}
