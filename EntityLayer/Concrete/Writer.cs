﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string WriterPassword { get; set; }
        public string? About { get; set; }
        public string? Image { get; set; }
        
        public bool? Status { get; set; }

        public List<Article> Articles { get; set; }

     
    }
}
