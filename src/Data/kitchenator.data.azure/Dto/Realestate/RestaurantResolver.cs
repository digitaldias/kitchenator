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
                    Country      = new Country
                    {
                        CountryCode = entity.GetString("countrycode"),
                        CountryName = entity.GetString("countryname")
                    }
                }
            };
        }

        public TableEntity ToTableEntity(Restaurant restaurant)
        {
            return new TableEntity(restaurant.City.CountryCode, restaurant.Name)
            {
                { "id"          , restaurant.Id },
                { "name"        , restaurant.Name },
                { "chefcapacity", restaurant.ChefCapacity },
                { "rent"        , restaurant.MonthlyRent },
                { "streetname"  , restaurant.Address.StreetName },
                { "streetnumber", restaurant.Address.StreetNumber },
                { "postalcode"  , restaurant.Address.PostalCode },
                { "countrycode" , restaurant.Address.Country.CountryCode },
                { "countryname" , restaurant.Address.Country.CountryName },
            };
        }
    }
}
