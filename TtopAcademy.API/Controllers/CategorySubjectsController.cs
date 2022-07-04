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
    /// <summary> Controller for CategorySubjects. </summary>
    public class CategorySubjectsController : ApiController
    {
        private readonly ICategorySubjectRepository categorySubjectRepository;

        /// <summary> Constructs a new CategorySubjects controller with given parameter. </summary>
        public CategorySubjectsController(ICategorySubjectRepository categorySubjectRepository)
        {
            this.categorySubjectRepository = categorySubjectRepository;
        }

        /// <summary> Returns all CategorySubjects. 
        ///     Route is GET: api/CategorySubjects </summary>
        public async Task<IEnumerable<CategorySubject>> Get()
        {
            return await categorySubjectRepository.GetAllCategorySubjectsAsync();
        }
    }
} 
