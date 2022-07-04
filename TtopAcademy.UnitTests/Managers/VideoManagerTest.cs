using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Infrastructure.Managers.Real;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;

namespace TtopAcademy.UnitTests.Managers
{
    [TestClass]
    public class VideoManagerTest
    {
        private IVideoManager videoManager; 
        private List<CategorySubjectTopic> testCategorySubjectTopics;
        private List<CategorySubjectTopicVideo> testCategorySubjectTopicVideos;
        private List<Video> testVideos;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            testCategorySubjectTopics = GetTestCegorySubjectTopics();
            testCategorySubjectTopicVideos = GetTestCegorySubjectTopicVideos();
            testVideos = GetTestVideos();

            ICategorySubjectTopicRepository fakeCategorySubjectTopicRepository =
                new FakeCategorySubjectTopicRepository(testCategorySubjectTopics);
            ICategorySubjectTopicVideoRepository fakeCategorySubjectTopicVideoRepository =
                new FakeCategorySubjectTopicVideoRepository(testCategorySubjectTopicVideos);
            IVideoRepository fakeVideoRepository = new FakeVideoRepository(testVideos);

            videoManager = new VideoManager(fakeVideoRepository, fakeCategorySubjectTopicRepository,
                                                    fakeCategorySubjectTopicVideoRepository);
        }

        [TestCleanup]
        public void CleanUpAfterEachTest()
        {
            testCategorySubjectTopics = null;
            testCategorySubjectTopicVideos = null;
            videoManager = null;
        }

        [TestMethod] 
        public async Task GetAllAsync_ShouldReturnAll() 
        {
            IEnumerable<Video> result = await videoManager.GetAllVideosAsync();
            Assert.AreEqual(testVideos.Count(), result.Count());
        }

        [TestMethod]
        public async Task GetVideosAsync_ShouldReturnForCategoryIDSubjectIDTopicID()
        {
            int categoryID = 1, subjectID = 1, topicID = 1;
            IEnumerable<Video> result = 
                await videoManager.GetVideosAsync(categoryID, subjectID, topicID);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetVideosAsync_ShouldReturnForCategorySubjectTopicID()
        {
            int categorySubjectTopicID = 1;
            IEnumerable<Video> result =
                await videoManager.GetVideosAsync(categorySubjectTopicID);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task SaveVideoAsync_ShouldReturnSavedEntry()
        {
            int categoryID = 1, subjectID = 1, topicID = 1;
            Video video = new Video
            {
                Number = 1, YoutubeID = "bhsgujd", Title = "Cell Theory",
                Size = "10", SolutionVideoYoutubeID = "betsghsjk",
                SolutionVideoSize = "20"
            };
            Video result =
                await videoManager.SaveVideoAsync(categoryID, subjectID, topicID, video);

            Assert.IsNotNull(result);
            Assert.AreEqual(video.YoutubeID, result.YoutubeID);
        }

        [TestMethod]
        public async Task UpdateVideoAsync_ShouldReturnUpdatedEntry()
        {
            Video video = new Video
            {
                VideoID = 1, Number = 1, YoutubeID = "bhsgujd",
                Title = "Cell Theory", Size = "10",
                SolutionVideoYoutubeID = "betsghsjk",
                SolutionVideoSize = "20"
            };
            Video result = await videoManager.UpdateVideoAsync(video);

            Assert.IsNotNull(result);
            Assert.AreEqual(video.YoutubeID, result.YoutubeID);
        }

        [TestMethod]
        public async Task DeleteVideoAsync_ShouldReturnDeletedEntry()
        {
            int categoryID = 1, subjectID = 1, topicID = 1, videoID = 1;
            Video result =
                await videoManager.DeleteVideoAsync(videoID, topicID, subjectID, categoryID);

            Assert.IsNotNull(result);
        }

        private List<CategorySubjectTopic> GetTestCegorySubjectTopics()
        {
            var testCategorySubjectTopics = new List<CategorySubjectTopic>
            {
                new CategorySubjectTopic {
                    CategorySubjectTopicID = 1, CategorySubjectID = 1, TopicID = 1,
                    CategorySubject = new CategorySubject{ CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                },
                new CategorySubjectTopic {
                    CategorySubjectTopicID = 2, CategorySubjectID = 1, TopicID = 2,
                    CategorySubject = new CategorySubject{ CategorySubjectID = 1, CategoryID = 1, SubjectID = 1}
                }
            };
            return testCategorySubjectTopics;
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

        private List<Video> GetTestVideos()
        {
            var testVideos = new List<Video>
            {
                new Video {
                    VideoID = 1, Number = 1, YoutubeID = "asheuiwowp", Title = "Add and Sub",
                    Size = "10", SolutionVideoYoutubeID = "auehejeke", SolutionVideoSize = "20"
                },
                new Video {
                    VideoID = 2, Number = 2, YoutubeID = "asheuiwowp", Title = "Div and Mult",
                    Size = "10", SolutionVideoYoutubeID = "auehejeke", SolutionVideoSize = "20"
                }

            };
            return testVideos;
        }
    }
}
