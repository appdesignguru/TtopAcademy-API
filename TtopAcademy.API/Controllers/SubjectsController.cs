using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TutorField.API.Models;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for subjects. </summary>
    [Authorize(Roles = "Adminstrator")]
    public class SubjectsController : ApiController
    {
        private readonly ISubjectManager subjectManager;

        /// <summary> Constructs a new subjects controller with given parameter. </summary>
        public SubjectsController(ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager;
        }

        /// <summary> Returns all subjects. Route is GET: api/Subjects </summary>
        [AllowAnonymous]
        public async Task<IEnumerable<Subject>> Get()
        {
            return await subjectManager.GetAllSubjectsAsync(); 
        }

        /// <summary> Returns all subjects for the given categoryID. 
        ///     Route is GET: api/Subjects/CategoryID</summary>
        [AllowAnonymous]
        public async Task<IEnumerable<Subject>> Get(int id) 
        {
            return await subjectManager.GetSubjectsAsync(id);
        }

        /// <summary> Saves the given data model. 
        ///     Route is POST: api/Subjects. </summary> 
        public async Task<IHttpActionResult> Post(SubjectBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject subject = await subjectManager.SaveSubjectAsync(model.CategoryID, new Subject
            {
                Number = model.Number,
                Name = model.Name
            });

            return Ok(subject);
        }

        /// <summary> Updates the given data model with the specified subjectID. 
        ///     Route is PUT: api/Subjects/SubjectID. </summary> 
        public async Task<IHttpActionResult> Put(int id, SubjectBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await subjectManager.UpdateSubjectAsync(new Subject
            {
                SubjectID = id,
                Number = model.Number,
                Name = model.Name
            });
            return Ok();
        }

        /// <summary> Deletes the subject with given concatenated string id parameter. Route is
        ///     DELETE: api/Subjects/CategoryID-SubjectID </summary>   
        public async Task<IHttpActionResult> Delete(string id)
        {
            string[] ids = id.Split('-');
            int categoryID = int.Parse(ids[0]);
            int subjectID = int.Parse(ids[1]);

            Subject dbEntry = await subjectManager.DeleteSubjectAsync(subjectID, categoryID);
            if (dbEntry == null) 
            {
                return BadRequest("CategoryID-SubjectID  is invalid");
            }
            return Ok();
        }
    }
}
