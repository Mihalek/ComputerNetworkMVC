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
        public string NameOfNetwork { get; set; }
        public string DateOfAdd { get; set; }
        [Required(ErrorMessage = "Name of Object is required")]
        public string NameOfElement { get; set; }
        [Required(ErrorMessage = "ID of Object is required")]
        public string IdOfElement { get; set; }
        [Required(ErrorMessage = "Ip Address of Object is required")]
        [StringLength(15)]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "Invalid Format")]
        public string IpAddress { get; set; }
        [Required(ErrorMessage = "Mask of Object is required")]
        [StringLength(15)]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "Invalid Format")]
        public string Mask { get; set; }
        [StringLength(15)]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b", ErrorMessage = "Invalid Format")]
        public string Gateway { get; set; }
        public string Image { get; set; }
        public string Label { get; set; }
        public string Shape { get; set; }
        public string Title { get; set; }

    }
}
