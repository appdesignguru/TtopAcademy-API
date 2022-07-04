﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TutorField.API.Models;

namespace TtopAcademy.API.Controllers
{
    [Authorize(Roles = "Adminstrator")]
    public class VideosController : ApiController
    {
        private readonly IVideoManager videoManager; 

        public VideosController(IVideoManager videoManager)
        {
            this.videoManager = videoManager;
        }

        // GET: api/Videos/CategoryID-SubjectID-TopicID 
        [AllowAnonymous] 
        public async Task<IEnumerable<Video>> Get(string id)
        {
            string[] ids = id.Split('-');
            int categoryID = int.Parse(ids[0]);
            int subjectID = int.Parse(ids[1]);
            int topicID = int.Parse(ids[1]);

            IEnumerable<Video> videos = await videoManager.GetVideosAsync(categoryID, subjectID, topicID);
            
            return videos;  
        }

        // POST: api/Videos
        public async Task<IHttpActionResult> Post(VideoBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Video video =new Video {
                Number = model.Number, YoutubeID = model.YoutubeID,
                Title = model.Title, Size = model.Size,
                SolutionVideoYoutubeID = model.SolutionVideoYoutubeID,
                SolutionVideoSize = model.SolutionVideoSize
            };

            Video dbEntry = await videoManager.SaveVideoAsync(model.CategoryID, model.SubjectID, model.TopicID, video);

            return Ok(dbEntry);
        }

        // PUT: api/Videos/VideoID
        public async Task<IHttpActionResult> Put(int id, VideoBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await videoManager.UpdateVideoAsync(new Video
            {
                VideoID = id,
                Number = model.Number,
                YoutubeID = model.YoutubeID,
                Title = model.Title,
                Size = model.Size,
                SolutionVideoYoutubeID = model.SolutionVideoYoutubeID,
                SolutionVideoSize = model.SolutionVideoSize
            });
            return Ok(); 
        }

        // DELETE: api/Videos/CategoryID-SubjectID-TopicID-VideoID
        public async Task<IHttpActionResult> Delete(string id) 
        {
            string[] ids = id.Split('-');
            int categoryID = int.Parse(ids[0]);
            int subjectID = int.Parse(ids[1]);
            int topicID = int.Parse(ids[1]);
            int videoID = int.Parse(ids[2]);

            Video dbEntry = await videoManager.DeleteVideoAsync(videoID, topicID, subjectID, categoryID);
            if (dbEntry == null)
            {
                return BadRequest("CategoryID-SubjectID-TopicID-VideoID is invalid");
            }
            return Ok();
        }
    }
}