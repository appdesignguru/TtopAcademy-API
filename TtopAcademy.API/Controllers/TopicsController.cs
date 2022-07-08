using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.Models; 

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for topics. </summary>
    [Authorize(Roles = "Adminstrator")]
    public class TopicsController : ApiController
    {
        private readonly ITopicManager topicManager;

        /// <summary> Constructs a new topics controller with given parameter. </summary>
        public TopicsController(ITopicManager topicManager)
        {
            this.topicManager = topicManager;
        }

        /// <summary> Returns all topics. Route is GET: api/Topics </summary>
        [AllowAnonymous]
        public async Task<IEnumerable<Topic>> Get()
        {
            return await topicManager.GetAllTopicsAsync(); 
        }

        /// <summary> Returns all topics for the given hypenConcatenatedCategoryAndSubjectID. 
        ///     Route is GET: api/Topics/hypenConcatenatedCategoryAndSubjectID </summary>
        [AllowAnonymous] 
        public async Task<IEnumerable<Topic>> Get(string id)
        {
            string[] ids = id.Split('-');
            int categoryID = int.Parse(ids[0]);
            int subjectID = int.Parse(ids[1]);

            IEnumerable<Topic> topics = await topicManager.GetTopicsAsync(categoryID, subjectID);
            
            return topics;
        }

        /// <summary> Saves the given data model. 
        ///     Route is POST: api/Topics. </summary> 
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

        /// <summary> Updates the given data model with the specified topicID. 
        ///     Route is PUT: api/Topics/TopicID. </summary> 
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

        /// <summary> Deletes the topic with given concatenated string id parameter. Route is
        ///     DELETE: api/Topics/CategoryID-SubjectID-TopicID </summary>  
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
