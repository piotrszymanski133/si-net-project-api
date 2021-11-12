using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using si_net_project_api.Services;

namespace si_net_project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataService _dataService;

        public DataController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("temperatures")]
        public ActionResult<List<DataModel>> GetTemperatures()
        {
            return _dataService.FindAllTemperatures();
        }
        
        [HttpGet]
        [Route("winds")]
        public ActionResult<List<DataModel>> GetWinds()
        {
            return _dataService.FindAllWinds();
        }
        
        [HttpGet]
        [Route("pressures")]
        public ActionResult<List<DataModel>> GetPressures()
        {
            return _dataService.FindAllPressures();
        }
        
        [HttpGet]
        [Route("humidities")]
        public ActionResult<List<DataModel>> GetHumidities()
        {
            return _dataService.FindAllHumidities();
        }
    }
}