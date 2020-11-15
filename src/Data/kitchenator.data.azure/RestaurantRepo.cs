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
            return allRestaurants.FirstOrDefault(r => r.Id.Equals(id));
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
                    Name         = entity.RowKey,
                    City         = new City { CountryCode = entity.PartitionKey, CityName = entity["city"].StringValue },
                    ChefCapacity = entity["chefcapacity"].Int32Value.Value,
                    MonthlyRent  = (decimal)entity["rent"].DoubleValue.Value
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
                PartitionKey = $"{restaurant.City.CountryCode}",
                RowKey       = restaurant.Name
            };

            entity.Properties.Add("id",           new EntityProperty(restaurant.Id.ToString()));
            entity.Properties.Add("city",         new EntityProperty(restaurant.City.CityName));
            entity.Properties.Add("rent",         new EntityProperty((double)restaurant.MonthlyRent));
            entity.Properties.Add("chefcapacity", new EntityProperty(restaurant.ChefCapacity));

            var upsertOperation = TableOperation.InsertOrReplace(entity);
            var upsertResult    = await Table.ExecuteAsync(upsertOperation);
            return upsertResult.HttpStatusCode >= 200 && upsertResult.HttpStatusCode <= 299;
        }
    }
}
