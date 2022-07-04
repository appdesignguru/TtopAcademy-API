using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> Subject repository interface. </summary>
    public interface ISubjectRepository
    {
        /// <summary> Returns all subjects. </summary>
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();

        /// <summary> Returns saved subject or null if saving not successful. </summary>
        Task<Subject> SaveSubjectAsync(Subject subject);

        /// <summary> Returns updated subject or null if the subject
        ///     to be updated does not exist. </summary> 
        Task<Subject> UpdateSubjectAsync(Subject subject);

        /// <summary> Returns deleted subject or null if the subject
        ///     to be deleted does not exist. </summary> 
        Task<Subject> DeleteSubjectAsync(int subjectID); 
    }
} 
