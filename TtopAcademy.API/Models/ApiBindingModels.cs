using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Entities.PracticeQuestions;

namespace TutorField.API.Models
{
    public class OtpBindingModel 
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public OtpType OtpType { get; set; }

        public int Code { get; set; }
    } 

    public class CategoryBindingModel
    {
        [Display(Name = "CategoryID")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; } 

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }

    public class CategorySubjectBindingModel
    {
        [Display(Name = "CategorySubjectID")]
        public int CategorySubjectID { get; set; }

        [Required]
        [Display(Name = "CategoryID")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }
    }

    public class CategorySubjectTopicBindingModel
    {
        [Display(Name = "CategorySubjectTopicID")]
        public int CategorySubjectTopicID { get; set; }

        [Required]
        [Display(Name = "CategorySubjectID")]
        public int CategorySubjectID { get; set; }

        [Required]
        [Display(Name = "TopicID")]
        public int TopicID { get; set; }
    }

    public class CategorySubjectTopicVideoBindingModel
    {
        [Display(Name = "CategorySubjectTopicVideoID")]
        public int CategorySubjectTopicVideoID { get; set; }

        [Required]
        [Display(Name = "CategorySubjectID")]
        public int CategorySubjectTopicID { get; set; }

        [Required]
        [Display(Name = "TopicID")]
        public int VideoID { get; set; }
    }

    public class SubjectBindingModel
    {
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; } 

        [Required]
        [Display(Name = "Subject Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
    }

    public class TopicBindingModel
    {
        [Display(Name = "TopicID")]
        public int TopicID { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }
    }

    public class VideoBindingModel
    {
        [Display(Name = "VideoID")]
        public int VideoID { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; } 

        [Required]
        [Display(Name = "Youtube ID")]
        public string YoutubeID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Youtube ID")]
        public string SolutionVideoYoutubeID { get; set; }

        [Required]
        [Display(Name = "Size")]
        public string SolutionVideoSize { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "SubjectID")]
        public int SubjectID { get; set; }

        [Required]
        [Display(Name = "TopicID")]
        public int TopicID { get; set; }
    }

    public class PracticeQuestionBindingModel
    {
        [Display(Name = "PracticeQuestionID")]
        public int PracticeQuestionID { get; set; }

        [Required]
        [Display(Name = "PracticeQuestionID")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "VideoID")]
        public int VideoID { get; set; }

        [Required]
        [Display(Name = "Quetion Number")]
        public int QuestionNumber { get; set; }

        [Required]
        [Display(Name = "Quetion")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "OptionA")]
        public string OptionA { get; set; }

        [Required]
        [Display(Name = "OptionB")]
        public string OptionB { get; set; }

        [Required]
        [Display(Name = "OptionC")]
        public string OptionC { get; set; }

        [Required]
        [Display(Name = "OptionD")]
        public string OptionD { get; set; }

        [Required]
        [Display(Name = "CorrectAnswer")]
        public Option CorrectOption { get; set; } 
    }


}