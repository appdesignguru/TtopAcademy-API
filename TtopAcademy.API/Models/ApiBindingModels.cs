using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TtopAcademy.API.Models  
{
    /// <summary> API Binding model for one time passord (OTP). </summary>
    public class OtpBindingModel 
    {
        /// <summary> User Email. </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary> OTP type. </summary>
        [Required]
        public OtpType OtpType { get; set; }

        /// <summary> OTP code. </summary>
        public int Code { get; set; }
    }

    /// <summary> API Binding model for category. </summary>
    public class CategoryBindingModel
    {
        /// <summary> CategoryID. Default value is 0. </summary>
        [Display(Name = "CategoryID")]
        public int CategoryID { get; set; }

        /// <summary> Category number. </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> Name of category. </summary>
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }

    /// <summary> API Binding model for CategorySubject. </summary>
    public class CategorySubjectBindingModel
    {
        /// <summary> CategorySubjectID. Default value is 0. </summary>
        [Display(Name = "CategorySubjectID")]
        public int CategorySubjectID { get; set; }

        /// <summary> CategoryID. </summary>
        [Required]
        [Display(Name = "CategoryID")]
        public int CategoryID { get; set; }

        /// <summary> SubjectID. </summary>
        [Required]
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }
    }

    /// <summary> API Binding model for CategorySubjectTopic. </summary>
    public class CategorySubjectTopicBindingModel
    {
        /// <summary> CategorySubjectTopicID. Default value is 0. </summary>
        [Display(Name = "CategorySubjectTopicID")]
        public int CategorySubjectTopicID { get; set; }

        /// <summary> CategorySubjectID. </summary>
        [Required]
        [Display(Name = "CategorySubjectID")]
        public int CategorySubjectID { get; set; }

        /// <summary> TopicID. </summary>
        [Required]
        [Display(Name = "TopicID")]
        public int TopicID { get; set; }
    }

    /// <summary> API Binding model for CategorySubjectTopicVideo. </summary>
    public class CategorySubjectTopicVideoBindingModel
    {
        /// <summary> CategorySubjectTopicVideoID. Default value is 0. </summary>
        [Display(Name = "CategorySubjectTopicVideoID")]
        public int CategorySubjectTopicVideoID { get; set; }

        /// <summary> CategorySubjectTopicID. </summary>
        [Required]
        [Display(Name = "CategorySubjectTopicID")] 
        public int CategorySubjectTopicID { get; set; }

        /// <summary> VideoID. </summary>
        [Required]
        [Display(Name = "TopicID")]
        public int VideoID { get; set; }
    }

    /// <summary> API Binding model for Subject. </summary>
    public class SubjectBindingModel
    {
        /// <summary> SubjectID. Default value is 0. </summary>
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }

        /// <summary> Subject number. </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> Subject name. </summary>
        [Required]
        [Display(Name = "Subject Name")]
        public string Name { get; set; }

        /// <summary> CategoryID. </summary>
        [Required]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
    }

    /// <summary> API Binding model for topic. </summary>
    public class TopicBindingModel
    {
        /// <summary> TopicID. Default value is 0. </summary>
        [Display(Name = "TopicID")]
        public int TopicID { get; set; }

        /// <summary> Topic number. </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> Topic name. </summary>
        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        /// <summary> CategoryID. </summary>
        [Required]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        /// <summary> SubjectID. </summary>
        [Required]
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }
    }

    /// <summary> API Binding model for video. </summary>
    public class VideoBindingModel
    {
        /// <summary> VideoID. Default value is 0. </summary>
        [Display(Name = "VideoID")]
        public int VideoID { get; set; }

        /// <summary> Video number. </summary>
        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        /// <summary> Tutorial video youtubeID. </summary>
        [Required]
        [Display(Name = "Youtube ID")]
        public string YoutubeID { get; set; }

        /// <summary> Tutorial video title. </summary>
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary> Tutorial video file size in MB. </summary>
        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        /// <summary> Solution video youtubeID. </summary>
        [Required]
        [Display(Name = "Youtube ID")]
        public string SolutionVideoYoutubeID { get; set; }

        /// <summary> Solution video file size in MB. </summary>
        [Required]
        [Display(Name = "Size")]
        public string SolutionVideoSize { get; set; }

        /// <summary> CategoryID. </summary>
        [Required]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        /// <summary> SubjectID. </summary>
        [Required]
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }

        /// <summary> TopicID. </summary>
        [Required]
        [Display(Name = "TopicID")]
        public int TopicID { get; set; }
    }

    /// <summary> API Binding model for practice question. </summary>
    public class PracticeQuestionBindingModel
    {
        /// <summary> PracticeQuestionID. Default value is 0. </summary>
        [Display(Name = "PracticeQuestionID")]
        public int PracticeQuestionID { get; set; }

        /// <summary> Subject name. </summary> 
        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        /// <summary> VideoID. </summary> 
        [Required]
        [Display(Name = "VideoID")]
        public int VideoID { get; set; }

        /// <summary> Question number. </summary> 
        [Required]
        [Display(Name = "Quetion Number")]
        public int QuestionNumber { get; set; }

        /// <summary> Question. </summary> 
        [Required]
        [Display(Name = "Quetion")]
        public string Question { get; set; }

        /// <summary> Option A. </summary> 
        [Required]
        [Display(Name = "OptionA")]
        public string OptionA { get; set; }

        /// <summary> Option B. </summary> 
        [Required]
        [Display(Name = "OptionB")]
        public string OptionB { get; set; }

        /// <summary> Option C. </summary> 
        [Required]
        [Display(Name = "OptionC")]
        public string OptionC { get; set; }

        /// <summary> Option D. </summary> 
        [Required]
        [Display(Name = "OptionD")]
        public string OptionD { get; set; }

        /// <summary> Correct Option. </summary> 
        [Required]
        [Display(Name = "CorrectOption")]
        public Option CorrectOption { get; set; } 
    }

}