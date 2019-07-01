using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerNetwork.Models
{
    public class Network
    {
        [Key]
        public int Id { get; set; }
        public string NameOfNetwork { get; set; }
        public string DateOfAdd { get; set; }
    }
}