using LampeRESTapi.Managers;
using LampLib.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LampeRESTapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LampsController : ControllerBase
    {
        private ILamp lampMgr = new LampManager();


        // GET: api/<LampsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        { 
            try
            {
                List<Lamp> searchAllLamps = lampMgr.GetAll();
                return Ok(searchAllLamps);
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
        }

        // GET: api/<LampsController>
        [HttpGet]
        [Route("SearchLampInfoByDevicename/{deviceName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SearchLampInfoByDevicename(string deviceName)
        {
            try
            {
                List<Lamp> searchedLampListByName = lampMgr.GetAllByDeviceName(deviceName);
                return Ok(searchedLampListByName);
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
        }

        // POST api/<LampsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public Lamp Post([FromBody] Lamp lamp)
        {
            return lampMgr.Create(lamp);
        }
    }
}
