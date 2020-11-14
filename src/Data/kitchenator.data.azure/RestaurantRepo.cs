using kitchenator.Domain;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Realestate;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{


    public class RestaurantRepo<TBoundedContext> : Repository<Restaurant, TBoundedContext>
        where TBoundedContext : IBoundedContext
    {
        const string RESTAURANTS_TABLE_NAME = "restaurants";

        public RestaurantRepo()
            : base(RESTAURANTS_TABLE_NAME)
        {
        }

         

        public override Task<bool> DeleteById(Guid Id)
        {
            return Task.FromResult(false);
        }

        public override async Task<Restaurant> GetById(Guid id)
        {
            var allRestaurants = await GetAll();
            return allRestaurants.FirstOrDefault(r => r.Id.Value.Equals(id));
        }

        public override async Task<IEnumerable<Restaurant>> GetAll()
        {
            await Initialize();

            var entities = await GetAllRecords();
            if (!entities.Any())
            {
                return new List<Restaurant>();
            }

            var list = new List<Restaurant>();
            foreach (var entity in entities)
            {                
                var restaurant = new Restaurant
                {
                    Id           = new Guid(entity["id"].StringValue),
                    Name         = new RestaurantName(entity.RowKey),
                    City         = new City { CountryCode = entity.PartitionKey, CityName = entity["city"].StringValue },
                    ChefCapacity = entity["chefcapacity"].Int32Value,
                    MonthlyRent  = (decimal)entity["rent"].DoubleValue
                };
                list.Add(restaurant);
            }
            return list;
        }

        public override async Task<bool> Upsert(Restaurant restaurant)
        {
            await Initialize();
            
            var entity = new DynamicTableEntity
            {
                PartitionKey = $"{restaurant.City.CountryCode.Value}",
                RowKey       = restaurant.Name.Value
            };

            entity.Properties.Add("id",           new EntityProperty(restaurant.Id.Value.ToString()));
            entity.Properties.Add("city",         new EntityProperty(restaurant.City.CityName.Value));
            entity.Properties.Add("rent",         new EntityProperty((double)restaurant.MonthlyRent.Value));
            entity.Properties.Add("chefcapacity", new EntityProperty(restaurant.ChefCapacity.Value));

            var upsertOperation = TableOperation.InsertOrReplace(entity);
            var upsertResult    = await Table.ExecuteAsync(upsertOperation);
            return upsertResult.HttpStatusCode >= 200 && upsertResult.HttpStatusCode <= 299;
        }
    }
}
