using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class CategorySubjectTopicVideo 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorySubjectTopicVideoID { get; set; }

        public int CategorySubjectTopicID { get; set; }
        public int VideoID { get; set; }

        [IgnoreDataMember]
        public virtual CategorySubjectTopic CategorySubjectTopic { get; set; }

        [IgnoreDataMember]
        public virtual Video Video { get; set; }

    }
}