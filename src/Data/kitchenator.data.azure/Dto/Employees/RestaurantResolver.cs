﻿using Azure.Data.Tables;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Employees;

namespace kitchenator.data.azure.Dto.Employees
{
    public class RestaurantResolver : IDtoResolver<Restaurant>
    {
        public string Tablename => "employmento0orestaurants";

        public Restaurant FromTableEntity(TableEntity entity)
        {
            return new Restaurant
            {
                Id                = entity.GetGuid("id").GetValueOrDefault(),
                Name              = entity.GetString("name"),
                CloseDate         = entity.GetDateTime("closed").GetValueOrDefault(),
                EmployeeCapacity  = entity.GetInt32("capacity").GetValueOrDefault(),
                CurrentlyEmployed = entity.GetInt32("employed").GetValueOrDefault(),
                Address           = new Address
                {
                    StreetName   = entity.GetString("streetname"),
                    StreetNumber = entity.GetString("streetnumber"),
                    PostalCode   = entity.GetString("postalcode"),
                    City        = new City
                    {
                        CountryCode = entity.GetString("countrycode"),
                        CityName    = entity.GetString("city")
                    }
                }
            };
        }

        public TableEntity ToTableEntity(Restaurant restaurant)
        {
            return new TableEntity(restaurant.Address.City.CountryCode, restaurant.Name)
            {
                { "id"          , restaurant.Id },
                { "name"        , restaurant.Name },
                { "closed"      , restaurant.CloseDate },
                { "capacity"    , restaurant.EmployeeCapacity },
                { "employed"    , restaurant.CurrentlyEmployed },
                { "streetname"  , restaurant.Address.StreetName },
                { "streetnumber", restaurant.Address.StreetNumber },
                { "postalcode"  , restaurant.Address.PostalCode },
                { "countrycode" , restaurant.Address.City.CountryCode },
                { "city"        , restaurant.Address.City.CityName},
            };
        }
    }
}
