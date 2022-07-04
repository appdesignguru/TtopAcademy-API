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
using TutorField.API.Models;

namespace TtopAcademy.API.Controllers
{
    [Authorize(Roles = "Adminstrator")]
    public class TopicsController : ApiController
    {
        private readonly ITopicManager topicManager;

        public TopicsController(ITopicManager topicManager)
        {
            this.topicManager = topicManager;
        }

        // GET: api/Topics
        [AllowAnonymous]
        public async Task<IEnumerable<Topic>> Get()
        {
            return await topicManager.GetAllTopicsAsync(); 
        }

        // GET: api/Topics/hypenConcatenatedCategoryAndSubjectID 
        [AllowAnonymous] 
        public async Task<IEnumerable<Topic>> Get(string id)
        {
            string[] ids = id.Split('-');
            int categoryID = int.Parse(ids[0]);
            int subjectID = int.Parse(ids[1]);

            IEnumerable<Topic> topics = await topicManager.GetTopicsAsync(categoryID, subjectID);
            
            return topics;
        }


        // POST: api/Topics
        public async Task<IHttpActionResult> Post(TopicBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Topic topic = new Topic {
                Number = model.Number, Name = model.Name
            };
            Topic dbEntry = await topicManager.SaveTopicAsync(model.CategoryID, model.SubjectID, topic);
            
            return Ok(dbEntry);
        }

        // PUT: api/Topics/TopicID
        public async Task<IHttpActionResult> Put(int id, TopicBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await topicManager.UpdateTopicAsync(new Topic
            {
                TopicID = id,
                Number = model.Number,
                Name = model.Name
            });
            return Ok();
        }

        // DELETE: api/Topics/CategoryID-SubjectID-TopicID   
        public async Task<IHttpActionResult> Delete(string id)
        {
            string[] ids = id.Split('-');
            int categoryID = int.Parse(ids[0]);
            int subjectID = int.Parse(ids[1]);
            int topicID = int.Parse(ids[2]);

            Topic dbEntry = await topicManager.DeleteTopicAsync(topicID, subjectID, categoryID);  
            if (dbEntry == null)
            {
                return BadRequest("CategoryID-SubjectID-TopicID is invalid"); 
            }
            return Ok();
        }
    }
}
