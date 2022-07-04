using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.ApplicationCore.Factories
{
    /// <summary> PracticeQuestion factory interface. </summary>
    public interface IPracticeQuestionFactory
    {
        /// <summary> Returns practice question repository for given subject name. </summary>
        IPracticeQuestionRepository CreatePracticeQuestionRepository(string subjectName); 
    }
}
