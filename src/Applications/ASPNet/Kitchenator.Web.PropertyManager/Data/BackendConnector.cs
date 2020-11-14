using kitchenator.Domain.Concepts.Realestate;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kitchenator.Web.PropertyManager.Data
{
    public class BackendConnector
    {
        readonly HttpClient _httpClient;

        readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            PropertyNameCaseInsensitive                      = true,
            PropertyNamingPolicy                             = JsonNamingPolicy.CamelCase
        };

        public BackendConnector(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<bool> AddRestaurant(AddRestaurantRequest model)
        {
            var jsonModel = JsonSerializer.Serialize(model, typeof(AddRestaurantRequest), jsonSerializerOptions);
            var stringContent = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("/restaurants", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch{                
            }
            return false;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var response = await _httpClient.GetAsync("/restaurants");
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Restaurant[]>(stream, jsonSerializerOptions);
        }

        public async Task<Restaurant> GetRestaurantById(string restaurantId)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                return null;
            }
            var response = await _httpClient.GetAsync($"/restaurants/{restaurantId}");
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Restaurant>(stream, jsonSerializerOptions);
        }
    }
}