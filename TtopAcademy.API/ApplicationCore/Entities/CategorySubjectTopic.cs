using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class CategorySubjectTopic 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorySubjectTopicID { get; set; }

        public int CategorySubjectID { get; set; }
        public int TopicID { get; set; }

        [IgnoreDataMember]
        public virtual CategorySubject CategorySubject { get; set; }

        [IgnoreDataMember]
        public virtual Topic Topic { get; set; }

    }
}