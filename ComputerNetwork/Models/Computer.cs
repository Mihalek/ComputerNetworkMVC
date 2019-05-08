using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerNetwork.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        public String IdOfElement { get; set; }
        public String IpAddress { get; set; }
        public String Mask { get; set; }
        public String Gateway { get; set; }
    }
}
