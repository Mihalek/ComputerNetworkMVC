using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public class Router
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdOfElement { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Required]
        public string Mask { get; set; }
        [Required]
        public string Gateway { get; set; }
    }
}
