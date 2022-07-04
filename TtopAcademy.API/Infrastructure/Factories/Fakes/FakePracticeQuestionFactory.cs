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
    public class FakePracticeQuestionFactory : IPracticeQuestionFactory
    {
        private List<PracticeQuestion> practiceQuestions;

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