using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class Category 
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        public int Number { get; set; }
        public string Name { get; set; } 

    }
}