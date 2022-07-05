using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;
using TtopAcademy.API.ApplicationCore.Factories;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;

namespace TtopAcademy.API.Infrastructure.Factories.Fakes
{
    /// <summary> Fake practice question factory implementation class. Used unit testing. </summary>
    public class FakePracticeQuestionFactory : IPracticeQuestionFactory
    {
        private readonly List<PracticeQuestion> practiceQuestions;

        /// <summary> Constructs a new FakePracticeQuestionFactory with given parameter. </summary>
        public FakePracticeQuestionFactory(List<PracticeQuestion> practiceQuestions)
        {
            this.practiceQuestions = practiceQuestions;
        }

        public IPracticeQuestionRepository CreatePracticeQuestionRepository(string subjectName)
        {
            return new FakePracticeQuestionRepository(practiceQuestions); 
        }
    }
}