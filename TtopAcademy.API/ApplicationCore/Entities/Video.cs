using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class Video 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideoID { get; set; }

        public int Number { get; set; }

        public string YoutubeID { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }

        public string SolutionVideoYoutubeID { get; set; }
        public string SolutionVideoSize { get; set; }

    }
}