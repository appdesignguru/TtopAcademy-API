using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class CategorySubject 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorySubjectID { get; set; }

        public int CategoryID { get; set; }
        public int SubjectID { get; set; }

        [IgnoreDataMember]
        public virtual Category Category { get; set; }

        [IgnoreDataMember]
        public virtual Subject Subject { get; set; }

    }
}