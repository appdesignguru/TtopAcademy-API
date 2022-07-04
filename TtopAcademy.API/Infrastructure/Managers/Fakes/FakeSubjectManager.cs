using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;

namespace TtopAcademy.API.Infrastructure.Managers.Fakes
{
    public class FakeSubjectManager : ISubjectManager
    {
        private List<CategorySubject> categorySubjects;

        public FakeSubjectManager(List<CategorySubject> categorySubjects)
        {
            this.categorySubjects = categorySubjects;
        }


        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
           List<Subject> subjects = new List<Subject>();
           foreach (CategorySubject categorySubject in categorySubjects)
           {
                subjects.Add(categorySubject.Subject);
           }
           return await Task.FromResult(subjects);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync(int categoryID)
        {
            List<Subject> subjects = new List<Subject>();
            foreach (CategorySubject categorySubject in categorySubjects)
            {
                if (categorySubject.CategoryID == categoryID)
                {
                    subjects.Add(categorySubject.Subject);
                }          
            }
            return await Task.FromResult(subjects);
        }

        public async Task<Subject> SaveSubjectAsync(int categoryID, Subject subject)
        {
            foreach (CategorySubject categorySubject in categorySubjects)
            {
                if (categorySubject.CategoryID == categoryID)
                {
                    subject.SubjectID = 100;
                    categorySubject.Subject = subject;
                    break;
                }
            }
            return await Task.FromResult(subject); 
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            foreach (CategorySubject categorySubject in categorySubjects)
            {
                if (categorySubject.SubjectID == subject.SubjectID)
                {
                    categorySubject.Subject = subject;
                    break;
                }
            }
            return await Task.FromResult(subject);
        }

        public async Task<Subject> DeleteSubjectAsync(int subjectID, int categoryID)
        {
            CategorySubject categorySubject =
                categorySubjects.FirstOrDefault(c => c.SubjectID == subjectID
                                                 && c.CategoryID == categoryID);
            if (categorySubject == null)
            {
                return null;
            }
            await Task.FromResult(categorySubjects.Remove(categorySubject));
            return categorySubject.Subject;
        }
    }
}