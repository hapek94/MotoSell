﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSell.Core.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}
