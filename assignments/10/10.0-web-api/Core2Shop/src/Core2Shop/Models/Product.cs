using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Core2Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string IMG { get; set; }
    }
}
