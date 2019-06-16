﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
