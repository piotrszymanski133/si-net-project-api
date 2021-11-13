using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<List<DataModel>> GetTemperatures(
            [FromQuery(Name="sdate")] DateTime sDate,
            [FromQuery(Name="edate")] DateTime eDate,
            [FromQuery(Name="sorted")] bool sorted = false,
            [FromQuery(Name="asc")] bool asc = true,
            [FromQuery(Name="hive")] int hive = -1)
        {
            List<DataModel> ret;
            if (eDate == new DateTime())
            {
                eDate = DateTime.Now;
            }
            if (eDate <= sDate)
            {
                return BadRequest();
            }

            if (hive < 0)
            {
                ret = _dataService.FindAllTemperaturesByDates(sDate, eDate);
            }
            else
            {
                ret = _dataService.FindAllTemperaturesByHiveAndDates(hive, sDate, eDate);
            }

            if(sorted)
            {
                ret.Sort((el1, el2) => el1.Value.CompareTo(el2.Value));
            }

            if (!asc)
            {
                ret.Reverse();
            }
            return ret;
        }

        [HttpGet]
        [Route("winds")]
        public ActionResult<List<DataModel>> GetWinds([FromQuery(Name = "sdate")] DateTime sDate,
            [FromQuery(Name = "edate")] DateTime eDate,
            [FromQuery(Name = "sorted")] bool sorted = false,
            [FromQuery(Name = "asc")] bool asc = true,
            [FromQuery(Name = "hive")] int hive = -1)
        {
            List<DataModel> ret;
            if (eDate == new DateTime())
            {
                eDate = DateTime.Now;
            }

            if (eDate <= sDate)
            {
                return BadRequest();
            }

            if (hive < 0)
            {
                ret = _dataService.FindAllWindsByDates(sDate, eDate);
            }
            else
            {
                ret = _dataService.FindAllWindsByHiveAndDates(hive, sDate, eDate);
            }

            if (sorted)
            {
                ret.Sort((el1, el2) => el1.Value.CompareTo(el2.Value));
            }

            if (!asc)
            {
                ret.Reverse();
            }

            return ret;
        }

        [HttpGet]
        [Route("pressures")]
        public ActionResult<List<DataModel>> GetPressures([FromQuery(Name = "sdate")] DateTime sDate,
            [FromQuery(Name = "edate")] DateTime eDate,
            [FromQuery(Name = "sorted")] bool sorted = false,
            [FromQuery(Name = "asc")] bool asc = true,
            [FromQuery(Name = "hive")] int hive = -1)
        {
            List<DataModel> ret;
            if (eDate == new DateTime())
            {
                eDate = DateTime.Now;
            }

            if (eDate <= sDate)
            {
                return BadRequest();
            }

            if (hive < 0)
            {
                ret = _dataService.FindAllPressuresByDates(sDate, eDate);
            }
            else
            {
                ret = _dataService.FindAllPressuresByHiveAndDates(hive, sDate, eDate);
            }

            if (sorted)
            {
                ret.Sort((el1, el2) => el1.Value.CompareTo(el2.Value));
            }

            if (!asc)
            {
                ret.Reverse();
            }

            return ret;
        }

        [HttpGet]
        [Route("humidities")]
        public ActionResult<List<DataModel>> GetHumidities([FromQuery(Name="sdate")] DateTime sDate,
            [FromQuery(Name="edate")] DateTime eDate,
            [FromQuery(Name="sorted")] bool sorted = false,
            [FromQuery(Name="asc")] bool asc = true,
            [FromQuery(Name="hive")] int hive = -1)
        {
            List<DataModel> ret;
            if (eDate == new DateTime())
            {
                eDate = DateTime.Now;
            }
            if (eDate <= sDate)
            {
                return BadRequest();
            }

            if (hive < 0)
            {
                ret = _dataService.FindAllHumiditiesByDates(sDate, eDate);
            }
            else
            {
                ret = _dataService.FindAllHumiditiesByHiveAndDates(hive, sDate, eDate);
            }

            if(sorted)
            {
                ret.Sort((el1, el2) => el1.Value.CompareTo(el2.Value));
            }

            if (!asc)
            {
                ret.Reverse();
            }
            return ret;
        }
    }
}