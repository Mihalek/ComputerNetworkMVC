using System;
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
        public string IdOfElement { get; set; }
        public string IpAddress { get; set; }
        public string Mask { get; set; }
        public string Gateway { get; set; }
    }
}
