using kitchenator.Domain.Concepts.Addresses;
using System.ComponentModel.DataAnnotations;

namespace Kitchenator.Web.PropertyManager.Data
{
    public class AddRestaurantRequest
    {
        [Required]
        [StringLength(150, ErrorMessage = "That is too much of a name!")]
        public string Name { get; set; }

        [Required]        
        public City City{ get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number of Chefs must be between 1-15")]
        public int ChefCapacity { get; set; }

        [Range(100, 150_000, ErrorMessage = "Yeah, not, I dont believe that rent is valid")]
        public decimal MonthlyRent { get; set; }
    }
}
