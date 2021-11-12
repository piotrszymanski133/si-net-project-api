using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using si_net_project_api.Services;

namespace si_net_project_api.Controllers
{
    [Route("api/[controller]/{hiveId:int}")]
    [ApiController]
    public class HiveDataController : ControllerBase
    {
        private readonly DataService _dataService;

        public HiveDataController(DataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        [Route("temperatures")]
        public ActionResult<List<DataModel>> GetHiveTemperatures(int hiveId)
        {
            return _dataService.FindAllTemperaturesByHive(hiveId);
        }
        
        [HttpGet]
        [Route("winds")]
        public ActionResult<List<DataModel>> GetHiveWinds(int hiveId)
        {
            return _dataService.FindAllWindsByHive(hiveId);
        }
        
        [HttpGet]
        [Route("pressures")]
        public ActionResult<List<DataModel>> GetHivePressures(int hiveId)
        {
            return _dataService.FindAllPressuresByHive(hiveId);
        }
        
        [HttpGet]
        [Route("humidities")]
        public ActionResult<List<DataModel>> GetHiveHumidities(int hiveId)
        {
            return _dataService.FindAllHumiditiesByHive(hiveId);
        }
    }
}