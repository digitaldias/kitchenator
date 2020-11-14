using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Dolittle.SDK;

namespace Kitchenator.EmailService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UptimeController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> Get()
        {
            var upTime         = DateTime.Now - Program.StartedAt;
            var assemblyName   = Assembly.GetExecutingAssembly().GetName();
            var serviceName    = assemblyName.Name;
            var serviceVersion = assemblyName.Version.ToString();
            var dolitleVersion = Assembly.GetAssembly(typeof(Client)).GetName().FullName;
            var thing          = new
            {
                Service = serviceName,
                Version = serviceVersion,
                Dolittle = dolitleVersion,
                Status  = "Healthy",
                Started = Program.StartedAt,
                Uptime  = upTime
            };
            return Task.FromResult<IActionResult>(Ok(thing));
        }
    }
}
