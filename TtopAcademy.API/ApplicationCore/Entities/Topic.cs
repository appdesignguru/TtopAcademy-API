﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class Topic 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicID { get; set; }

        public int Number { get; set; }
        public string Name { get; set; }

    }
}