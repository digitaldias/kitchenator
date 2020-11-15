using Azure.Data.Tables;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Realestate;

namespace kitchenator.data.azure.Dto.Realestate
{
    public class RestaurantResolver : IDtoResolver<Restaurant>
    {
        public string Tablename => "realestateo0orestaurants";

        public Restaurant FromTableEntity(TableEntity entity)
        {
            return new Restaurant
            {
                Id           = entity.GetGuid("id").GetValueOrDefault(),
                Name         = entity.GetString("name"),
                ChefCapacity = entity.GetInt32("chefcapacity").GetValueOrDefault(),
                MonthlyRent  = (decimal)entity.GetDouble("rent").GetValueOrDefault(),
                Address      = new Address
                {
                    StreetName   = entity.GetString("streetname"),
                    StreetNumber = entity.GetString("streetnumber"),
                    PostalCode   = entity.GetString("postalcode"),
                    City      = new City
                    {
                        CityName     = entity.GetString("city"),
                        CountryCode  = entity.GetString("countrycode")
                    }
                },
                SeatingCapacity = entity.GetInt32("seats").GetValueOrDefault(),
                SquareMeters = entity.GetInt32("size").GetValueOrDefault(),
            };
        }

        public TableEntity ToTableEntity(Restaurant restaurant)
        {
            return new TableEntity(restaurant.Address.City.CountryCode, restaurant.Name)
            {
                { "id"          , restaurant.Id },
                { "name"        , restaurant.Name },
                { "chefcapacity", restaurant.ChefCapacity },
                { "rent"        , (double) restaurant.MonthlyRent },
                { "streetname"  , restaurant.Address?.StreetName ?? string.Empty },
                { "streetnumber", restaurant.Address?.StreetNumber ?? string.Empty },
                { "postalcode"  , restaurant.Address?.PostalCode ?? string.Empty },
                { "countrycode" , restaurant.Address?.City.CountryCode ?? string.Empty },
                { "city"        , restaurant.Address?.City.CityName ?? string.Empty },
                { "seats"       , restaurant.SeatingCapacity },
                { "size"        , restaurant.SquareMeters },
            };
        }
    }
}
