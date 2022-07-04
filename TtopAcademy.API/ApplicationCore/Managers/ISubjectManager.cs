using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Managers
{
    /// <summary> Interface for managing subjects. </summary>
    public interface ISubjectManager
    {
        /// <summary> Returns all subjects. </summary>
        Task<IEnumerable<Subject>> GetAllSubjectsAsync(); 

        /// <summary> Returns subjects for given parameter. </summary>
        Task<IEnumerable<Subject>> GetSubjectsAsync(int categoryID);

        /// <summary> Returns saved subject or null if saving not successful. </summary>
        Task<Subject> SaveSubjectAsync(int categoryID, Subject subject);

        /// <summary> Returns updated subject or null if the subject
        ///     to be updated does not exist. </summary> 
        Task<Subject> UpdateSubjectAsync(Subject subject);

        /// <summary> Returns deleted subject or null if the subject
        ///     to be deleted does not exist. </summary> 
        Task<Subject> DeleteSubjectAsync(int subjectID, int categoryID); 
    }
}
