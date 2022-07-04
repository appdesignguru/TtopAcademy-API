using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Real
{
    /// <summary> CategorySubject repository class. </summary> 
    public class CategorySubjectRepository : ICategorySubjectRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new CategorySubject repository with given parameter. </summary> 
        public CategorySubjectRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategorySubject>> GetAllCategorySubjectsAsync() 
        {
            return await Task.FromResult(context.CategorySubjects);
        }
         
        public async Task<IEnumerable<CategorySubject>> GetCategorySubjectsAsync(int categoryID)
        {
            return await Task.FromResult(context.CategorySubjects.Where(p => p.CategoryID == categoryID));
        }

        public async Task<CategorySubject> GetCategorySubjectAsync(int categoryID, int subjectID)
        {
            return await Task.FromResult(context.CategorySubjects.FirstOrDefault(p => p.CategoryID == categoryID && p.SubjectID == subjectID));
        }

        public async Task<int> GetCategorySubjectIDAsync(int categoryID, int subjectID)
        {
            return (await GetCategorySubjectAsync(categoryID, subjectID)).CategorySubjectID;
        }

        public async Task<CategorySubject> DeleleteCategorySubjectAsync(int categoryID, int subjectID) 
        {
            CategorySubject dbEntry = context.CategorySubjects.FirstOrDefault(p => p.CategoryID == categoryID && p.SubjectID == subjectID);
            if (dbEntry != null)
            {
                context.CategorySubjects.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        } 

        public async Task<CategorySubject> SaveCategorySubjectAsync(CategorySubject categorySubject)
        {
            context.CategorySubjects.Add(categorySubject);
            await context.SaveChangesAsync();
            return GetCategorySubject(categorySubject.CategoryID, categorySubject.SubjectID);
        }

        private CategorySubject GetCategorySubject(int categoryID, int subjectID)
        {
            return context.CategorySubjects.FirstOrDefault(p => p.CategoryID == categoryID
                                                            && p.SubjectID == subjectID);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}