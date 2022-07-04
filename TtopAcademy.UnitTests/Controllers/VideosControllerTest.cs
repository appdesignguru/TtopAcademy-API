using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Managers.Fakes;
using TtopAcademy.API.Infrastructure.Managers.Real;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;
using TutorField.API.Models;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass]
    public class VideosControllerTest
    {
        private VideosController videosController;
        private List<CategorySubjectTopicVideo> testCategorySubjectTopicVideos;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            testCategorySubjectTopicVideos = GetTestCegorySubjectTopicVideos();
            IVideoManager fakeVideoManager = new FakeVideoManager(testCategorySubjectTopicVideos);

            videosController = new VideosController(fakeVideoManager); 
        }

        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            testCategorySubjectTopicVideos = null;
            videosController = null;
        }

        [TestMethod]
        public async Task Get_ShouldReturnForCategoryIDSubjectIDTopicID()
        { 
            string id = "1-1-1";  // id = CategoryID-SubjectID-TopicID
            var result = await videosController.Get(id) as IEnumerable<Video>;
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public async Task Post_ShouldReturnPostedEntry()
        {
            VideoBindingModel model = new VideoBindingModel
            {
                Number = 1, YoutubeID = "bhsgujd", Title = "Cell Theory",
                Size = "10", SolutionVideoYoutubeID = "betsghsjk",
                SolutionVideoSize = "20", CategoryID = 1, SubjectID = 1,
                TopicID = 1
            };
            var result = await videosController.Post(model) as OkNegotiatedContentResult<Video>;

            Assert.IsNotNull(result);
            Assert.AreEqual(model.YoutubeID, result.Content.YoutubeID);
        }

        [TestMethod]
        public async Task Put_ShouldReturnOk()
        {
            VideoBindingModel model = new VideoBindingModel
            {
                VideoID = 1,Number = 1, YoutubeID = "asheuiwowp",
                Title = "Addition and Sub", Size = "10",
                SolutionVideoYoutubeID = "auehejeke",
                SolutionVideoSize = "20", CategoryID = 1,
                SubjectID = 1, TopicID = 1
            };
            IHttpActionResult actionResult = await videosController.Put(1, model);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public async Task Delete_ShouldReturnOk()
        {
            string id = "1-1-1-1";  // id = CategoryID-SubjectID-TopicID-VideoID
            IHttpActionResult actionResult = await videosController.Delete(id);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        private List<CategorySubjectTopicVideo> GetTestCegorySubjectTopicVideos()
        {
            var testCategorySubjectTopicVideos = new List<CategorySubjectTopicVideo>
            {
                new CategorySubjectTopicVideo {
                    CategorySubjectTopicVideoID = 1, CategorySubjectTopicID = 1, VideoID = 1,
                    CategorySubjectTopic = new CategorySubjectTopic {
                        CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                        CategorySubject = new CategorySubject{ CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                    },
                    Video = new Video{ VideoID = 1}
                },
                new CategorySubjectTopicVideo {
                    CategorySubjectTopicVideoID = 1, CategorySubjectTopicID = 1, VideoID = 2,
                    CategorySubjectTopic = new CategorySubjectTopic {
                        CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                        CategorySubject = new CategorySubject{ CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                    },
                    Video = new Video{ VideoID = 1}
                }
            };
            return testCategorySubjectTopicVideos;
        }


    }
}
