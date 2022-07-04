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
    public class SubjectsController : ApiController
    {
        private readonly ISubjectManager subjectManager;

        public SubjectsController(ISubjectManager subjectManager)
        {
            this.subjectManager = subjectManager;
        }

        // GET: api/Subjects
        [AllowAnonymous]
        public async Task<IEnumerable<Subject>> Get()
        {
            return await subjectManager.GetAllSubjectsAsync(); 
        }

        // GET: api/Subjects/CategoryID
        [AllowAnonymous]
        public async Task<IEnumerable<Subject>> Get(int id) 
        {
            return await subjectManager.GetSubjectsAsync(id);
        }

        // POST: api/Subjects
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

        // PUT: api/Subjects/SubjectID
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

        // DELETE: api/Subjects/CategoryID-SubjectID  
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
