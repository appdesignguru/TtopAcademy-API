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
    /// <summary> Controller for CategorySubjectTopics. </summary>
    public class CategorySubjectTopicsController : ApiController
    {
        private readonly ICategorySubjectTopicRepository categorySubjectTopicRepository;

        /// <summary> Constructs a new CategorySubjectTopics controller with given parameter. </summary>
        public CategorySubjectTopicsController(ICategorySubjectTopicRepository categorySubjectTopicRepository)
        {
            this.categorySubjectTopicRepository = categorySubjectTopicRepository;
        }

        /// <summary> Returns all CategorySubjectTopics. 
        ///     Route is GET: api/CategorySubjectTopics </summary>
        public async Task<IEnumerable<CategorySubjectTopic>> Get() 
        {
            return await categorySubjectTopicRepository.GetAllCategorySubjectTopicsAsync();
        }
    }
}
