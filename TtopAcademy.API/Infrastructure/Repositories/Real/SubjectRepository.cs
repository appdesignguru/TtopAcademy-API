using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Models;

namespace TtopAcademy.API.Infrastructure.Repositories.Real
{
    /// <summary> Subject repository class. </summary> 
    public class SubjectRepository : ISubjectRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new subject repository with given parameter. </summary> 
        public SubjectRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await Task.FromResult(context.Subjects);
        }

        public async Task<Subject> DeleteSubjectAsync(int subjectID)
        {
            Subject dbEntry = await context.Subjects.FindAsync(subjectID);
            if (dbEntry != null)
            {
                context.Subjects.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<Subject> SaveSubjectAsync(Subject subject)
        {
            context.Subjects.Add(subject);
            await context.SaveChangesAsync();
            return GetSubject(subject.Name, subject.Number);
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            Subject dbERntry = await context.Subjects.FindAsync(subject.SubjectID);
            if (dbERntry != null)
            {
                dbERntry.Number = subject.Number;
                dbERntry.Name = subject.Name;
            }
            await context.SaveChangesAsync();
            return dbERntry;
        }

        private Subject GetSubject(string subjectName, int subjectNumber)
        {
            return context.Subjects.FirstOrDefault(p => p.Name == subjectName && p.Number == subjectNumber);
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