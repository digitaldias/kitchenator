using System;
using System.ComponentModel.DataAnnotations;

namespace Kitchenator.Web.CustomerSite.Models
{
    public class OrderTacoModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "That taco name is way too long!")]
        public string Name { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number of tacos invalid (1-20)")]
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Price { get; set; }

        public decimal Sum { get; set; }
    }
}
