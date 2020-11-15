using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts.Managers;
using kitchenator.Domain.Entities.Realestate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchenator.PropertyService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantsController : Controller
    {
        readonly IRealestateManager _realestateManager;

        public RestaurantsController(IRealestateManager realestateManager)
        {
            _realestateManager = realestateManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _realestateManager.GetAll();
            if(!results?.Any() ?? true)
            {
                return NotFound("No restaurants loaded");
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var match = await _realestateManager.GetById(id);
            if(match is { })
            {
                return Ok(match);
            }
            return NotFound(id);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRestaurantRequest request, CancellationToken token)
        {
            var restaurant = new Restaurant
            {
                Id           = Guid.NewGuid(),
                Name         = request.Name,
                ChefCapacity = request.ChefCapacity,
                MonthlyRent  = request.MonthlyRent,
                City         = request.City
            };

            var created = await _realestateManager.CreateRestaurant(restaurant, token);
            if(!created)
            {
                return UnprocessableEntity($"Failed to update the readmodel '{nameof(Restaurant)}'");
            }
            return Ok();
        }
    }
}