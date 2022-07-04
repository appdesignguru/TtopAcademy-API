using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    public class FakeCategorySubjectRepository : ICategorySubjectRepository
    {
        private readonly List<CategorySubject> categorySubjects;

        public FakeCategorySubjectRepository(List<CategorySubject> categorySubjects)
        {
            this.categorySubjects = categorySubjects;
        }

        public async Task<IEnumerable<CategorySubject>> GetAllCategorySubjectsAsync()
        {
            return await Task.FromResult(categorySubjects);
        }

        public async Task<IEnumerable<CategorySubject>> GetCategorySubjectsAsync(int categoryID)
        {
            return await Task.FromResult(categorySubjects.Where(p => p.CategoryID == categoryID));
        }

        public async Task<CategorySubject> GetCategorySubjectAsync(int categoryID, int subjectID)
        {
            return await Task.FromResult(categorySubjects.FirstOrDefault(p => p.CategoryID == categoryID && p.SubjectID == subjectID));
        }

        public async Task<int> GetCategorySubjectIDAsync(int categoryID, int subjectID)
        {
            return (await GetCategorySubjectAsync(categoryID, subjectID)).CategorySubjectID; 
        }

        public async Task<CategorySubject> DeleleteCategorySubjectAsync(int categoryID, int subjectID)
        {
            return await Task.FromResult(DeleteCategorySubject(categoryID, subjectID)); 
        }

        public async Task<CategorySubject> SaveCategorySubjectAsync(CategorySubject categorySubject)
        {
            return await Task.FromResult(SaveCategorySubject(categorySubject));
        }

        private CategorySubject DeleteCategorySubject(int categoryID, int subjectID) 
        {
            CategorySubject categorySubject = categorySubjects.FirstOrDefault(p => p.CategoryID == categoryID && p.SubjectID == subjectID);
            if (categorySubject != null)
            {
                categorySubjects.Remove(categorySubject);
            }
            return categorySubject;
        }

        private CategorySubject SaveCategorySubject(CategorySubject categorySubject)
        {
            CategorySubject entry = new CategorySubject
            {
                CategorySubjectID = 200,
                CategoryID = categorySubject.CategoryID,
                SubjectID = categorySubject.SubjectID
            };
            categorySubjects.Add(entry);
            return entry;
        }

    }
}