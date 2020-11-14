using Dolittle.SDK.Events.Store;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Entities.Realestate;
using kitchenator.Domain.Events.Realestate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchenator.PropertyService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantsController : Controller
    {
        readonly IEventStore _eventStore;        
        readonly IRepositoryFor<Restaurant, IBoundedContext.RealEstate> _restaurantRepo;
        List<Restaurant> _restaurants;

        public RestaurantsController(
            IEventStore eventStore,
            IRepositoryFor<Restaurant, IBoundedContext.RealEstate> restaurantRepo)
        {
            _restaurants    = new List<Restaurant>();
            _eventStore     = eventStore;
            _restaurantRepo = restaurantRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _restaurants = new List<Restaurant>(await _restaurantRepo.GetAll());

            return Ok(_restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if(!Guid.TryParse(id, out Guid restaurantId))
            {
                return BadRequest();
            }
            return Ok(await _restaurantRepo.GetById(restaurantId));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRestaurantRequest request)
        {
            // Pretend we just did a whole lotta validation right here
            var createRequest = new RestaurantCreationRequested
            {
                RestaurantId = new RestaurantId(Guid.NewGuid()),
                Name         = request.Name,
                City         = request.City,
                ChefCapacity = request.ChefCapacity,
                MonthlyRent  = request.MonthlyRent
            };
            var commitResult = await _eventStore.CommitEvent(createRequest, createRequest.RestaurantId.Value);
            if (!commitResult?.Any() ?? false)
                return BadRequest($"Failed to commit the request '{nameof(AddRestaurantRequest)}'");

            //TODO: Remove this once our EventHandler actually knows how to listen to events            
            if(await _restaurantRepo.Upsert(new Restaurant {
                Id           = Guid.NewGuid(),
                Name         = request.Name,
                ChefCapacity = request.ChefCapacity,
                MonthlyRent  = request.MonthlyRent,
                City         = request.City
            }))
            {
                return Ok("We're good!");
            }
            return UnprocessableEntity($"Failed to upsert readmodel '{nameof(Restaurant)}'");
        }
    }
}