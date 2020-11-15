using kitchenator.Domain.Concepts.Addresses;
using System.ComponentModel.DataAnnotations;

namespace kitchenator.Domain.Entities.Realestate
{
    public class AddRestaurantRequest
    {
        [Required]
        [StringLength(150, ErrorMessage = "That is too much of a name!")]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "That is too much of a street name!")]
        public string StreetName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "That is too much of a streetnumber!")]
        public string StreetNumber { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Honestly, that doesent smell like a zipcode")]
        public string ZipCode { get; set; }

        [Required]
        [Range(1, 1800, ErrorMessage = "Number of Chefs must be between 1 and 1 800")]
        public int ChefCapacity { get; set; }

        [Range(100, 550_000, ErrorMessage = "Yeah, not, I dont believe that rent is valid")]
        public decimal MonthlyRent { get; set; }

        [Required]
        [Range(1, 6000, ErrorMessage = "Number of seats must be between 1-6000")]
        public int SeatingCapacity { get; set; }

        [Required]
        [Range(1, 54000, ErrorMessage = "Values between 1 and 54 000sqm please")]
        public int SquareMeters { get; set; }
    }
}
