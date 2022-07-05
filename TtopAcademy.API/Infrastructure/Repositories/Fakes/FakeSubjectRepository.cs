using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    /// <summary> Fake subject repository implemetation class. Used for unit testing. </summary>
    public class FakeSubjectRepository : ISubjectRepository
    {
        private readonly List<Subject> subjects;

        /// <summary> Constructs a new FakeSubjectRepository with given parameter. </summary>
        public FakeSubjectRepository(List<Subject> subjects)
        {
            this.subjects = subjects;
        } 

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await Task.FromResult(subjects);
        }

        public Task<Subject> DeleteSubjectAsync(int subjectID)
        {
            return Task.FromResult(DeleteSubject(subjectID));
        }

        public Task<Subject> SaveSubjectAsync(Subject subject)
        {
            return Task.FromResult(SaveSubject(subject));
        }

        public Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            return Task.FromResult(UpdateSubject(subject));
        }

        private Subject DeleteSubject(int subjectID)
        {
            Subject subject = subjects.FirstOrDefault(c => c.SubjectID == subjectID);
            if (subject != null)
            {
                subjects.Remove(subject);
            }
            return subject;
        }

        private Subject SaveSubject(Subject subject)
        {
            Subject entry = new Subject
            {
                SubjectID = 500,
                Number = subject.Number,
                Name = subject.Name,
            };
            subjects.Add(entry);
            return entry;
        }

        private Subject UpdateSubject(Subject subject) 
        {
            Subject entry = subjects.FirstOrDefault(c => c.SubjectID == subject.SubjectID);
            if (entry != null)
            {
                entry.SubjectID = subject.SubjectID;
                entry.Number = subject.Number;
                entry.Name = subject.Name;
            }
            return entry;
        }
    }
}