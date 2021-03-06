﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public class Edge
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string NameOfNetwork { get; set; }
        public string DateOfAdd { get; set; }
    }
}
