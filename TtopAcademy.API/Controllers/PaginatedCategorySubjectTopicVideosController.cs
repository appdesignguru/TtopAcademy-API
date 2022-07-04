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
    /// <summary> Controller for paginated CategorySubjectTopicVideos </summary>
    public class PaginatedCategorySubjectTopicVideosController : ApiController
    {
        private readonly ICategorySubjectTopicVideoRepository repository;

        /// <summary> Constructs a new PaginatedCategorySubjectTopicVideos
        ///     controller with given parameter. </summary>
        public PaginatedCategorySubjectTopicVideosController(ICategorySubjectTopicVideoRepository repository)
        {
            this.repository = repository;
        }

        /// <summary> Returns 100 CategorySubjectTopicVideos whose CategorySubjectTopicID
        ///     is greater than the specified id. Route is
        ///     GET: api/PaginatedCategorySubjectTopicVideo/CategorySubjectTopicID </summary> 
        public async Task<IEnumerable<CategorySubjectTopicVideo>> Get(int id)
        {
            return (await repository.GetAllAsync()).Where(p => p.CategorySubjectTopicVideoID > id).Take(100);
        }
    }
} 
