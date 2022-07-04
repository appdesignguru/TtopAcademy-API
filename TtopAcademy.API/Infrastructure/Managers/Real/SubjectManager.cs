using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Managers.Real  
{
    /// <summary> Class for managing subjects. </summary>
    public class SubjectManager : ISubjectManager
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly ICategorySubjectRepository categorySubjectRepository;

        /// <summary> Constructs a new subject manager with given parameters. </summary> 
        public SubjectManager(ISubjectRepository subjectRepository,
            ICategorySubjectRepository categorySubjectRepository)
        {

            this.subjectRepository = subjectRepository;
            this.categorySubjectRepository = categorySubjectRepository;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await subjectRepository.GetAllSubjectsAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync(int categoryID)
        {
            IEnumerable<CategorySubject> categorySubjects = 
                await categorySubjectRepository.GetCategorySubjectsAsync(categoryID);
            List<Subject> subjects = new List<Subject>();
            foreach (CategorySubject categorySubject in categorySubjects)
            {
                subjects.Add(categorySubject.Subject);
            }
            return subjects;
        }

        public async Task<Subject> SaveSubjectAsync(int categoryID, Subject subject)
        {
            Subject dbEntry = await subjectRepository.SaveSubjectAsync(subject);
            await SaveCategorySubjectAsync(subject.SubjectID, categoryID);
            return dbEntry;
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            Subject dbEntry = await subjectRepository.UpdateSubjectAsync(subject);
            return dbEntry;
        }

        public async Task<Subject> DeleteSubjectAsync(int subjectID, int categoryID)
        {
            CategorySubject categorySubject = await categorySubjectRepository.DeleleteCategorySubjectAsync(categoryID, subjectID);
            Subject subject = await subjectRepository.DeleteSubjectAsync(subjectID);
            if (categorySubject == null || subject == null)
            {
                return null;
            }
            return subject;
        }

        private async Task SaveCategorySubjectAsync(int subjectID, int categoryID)
        {
            CategorySubject categorySubject = await categorySubjectRepository.GetCategorySubjectAsync(categoryID, subjectID);
            if (categorySubject == null)
            {
                await categorySubjectRepository.SaveCategorySubjectAsync(new CategorySubject
                {
                    CategoryID = categoryID,
                    SubjectID = subjectID
                });
            }
        }
    }
}