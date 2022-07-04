using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> CategorySubject repository interface. </summary>
    public interface ICategorySubjectRepository
    {
        /// <summary> Returns all CategorySubjects. </summary>
        Task<IEnumerable<CategorySubject>> GetAllCategorySubjectsAsync(); 

        /// <summary> Returns all CategorySubjects for given parameter. </summary>
        Task<IEnumerable<CategorySubject>> GetCategorySubjectsAsync(int categoryID);

        /// <summary> Returns CategorySubject for given parameters or null if it doesn't exist. </summary> 
        Task<CategorySubject> GetCategorySubjectAsync(int categoryID, int subjectID);

        /// <summary> Returns CategorySubjectID for given parameters. </summary> 
        Task<int> GetCategorySubjectIDAsync(int categoryID, int subjectID);

        /// <summary> Returns saved CategorySubject or null if saving not successful. </summary>
        Task<CategorySubject> SaveCategorySubjectAsync(CategorySubject categorySubject);

        /// <summary> Returns deleted CategorySubject or null if the CategorySubject
        ///     to be deleted does not exist. </summary> 
        Task<CategorySubject> DeleleteCategorySubjectAsync(int categpryID, int subjectID);  
    } 
}
