using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace si_net_project_api.Services
{
    public class DataService
    {
        private readonly IMongoCollection<DataModel> _temperatureData;
        private readonly IMongoCollection<DataModel> _windData;
        private readonly IMongoCollection<DataModel> _humidityData;
        private readonly IMongoCollection<DataModel> _pressureData;

        public DataService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _temperatureData = db.GetCollection<DataModel>(settings.TemperatureCollection);
            _windData = db.GetCollection<DataModel>(settings.WindCollection);
            _humidityData = db.GetCollection<DataModel>(settings.HumidityCollection);
            _pressureData = db.GetCollection<DataModel>(settings.PressureCollection);
        }

        public List<DataModel> FindAllTemperatures()
        {
            return AddTypeFieldToCollectionOfModelData(
                _temperatureData.Find(temperature => true).ToList(), "temperatures");
        }
        
        public List<DataModel> FindAllWinds()
        {
            return AddTypeFieldToCollectionOfModelData(
                _windData.Find(wind => true).ToList(), "winds");
        }
        public List<DataModel> FindAllPressures()
        {
            return AddTypeFieldToCollectionOfModelData(
                _pressureData.Find(pressure => true).ToList(), "pressures");
        }
        public List<DataModel> FindAllHumidities()
        {
            return AddTypeFieldToCollectionOfModelData(
                _humidityData.Find(humidity => true).ToList(), "humidities");
        }

        public List<DataModel> FindAllTemperaturesByHive(int hiveId)
        {
            return AddTypeFieldToCollectionOfModelData(
                _temperatureData.Find(temperature => temperature.HiveId == hiveId).ToList(), "temperatures");
        }
        public List<DataModel> FindAllWindsByHive(int hiveId)
        {
            return AddTypeFieldToCollectionOfModelData(
                _windData.Find(wind => wind.HiveId == hiveId).ToList(), "winds");
        }
        public List<DataModel> FindAllPressuresByHive(int hiveId)
        {
            return AddTypeFieldToCollectionOfModelData(
                _pressureData.Find(pressure => pressure.HiveId == hiveId).ToList(), "pressures");
        }
        public List<DataModel> FindAllHumiditiesByHive(int hiveId)
        {
            return AddTypeFieldToCollectionOfModelData(
                _humidityData.Find(humidity => humidity.HiveId == hiveId).ToList(), "humidities");
        }

        public List<DataModel> FindAllTemperaturesByDates(DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _temperatureData.Find(temperature => start <= temperature.DateTime && temperature.DateTime < end).ToList(),
                "temperatures");
        }

        public List<DataModel> FindAllTemperaturesByHiveAndDates(int hive, DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _temperatureData.Find(temperature => temperature.HiveId == hive && start <= temperature.DateTime && temperature.DateTime < end)
                    .ToList()
                , "temperatures");
            
        }
        
        public List<DataModel> FindAllWindsByDates(DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _windData.Find(wind => start <= wind.DateTime && wind.DateTime < end).ToList(),
                "winds");
        }

        public List<DataModel> FindAllWindsByHiveAndDates(int hive, DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _windData.Find(wind => wind.HiveId == hive && start <= wind.DateTime && wind.DateTime < end).ToList(),
                "winds");
        }
        
        public List<DataModel> FindAllPressuresByDates(DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _pressureData.Find(pressure => start <= pressure.DateTime && pressure.DateTime < end).ToList(),
                "pressures");
        }

        public List<DataModel> FindAllPressuresByHiveAndDates(int hive, DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(_pressureData
                    .Find(pressure => pressure.HiveId == hive && start <= pressure.DateTime && pressure.DateTime < end).ToList(),
                "pressures");
        }
        
        public List<DataModel> FindAllHumiditiesByDates(DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _humidityData.Find(humidity => start <= humidity.DateTime && humidity.DateTime < end).ToList(),
                "humidities");
        }

        public List<DataModel> FindAllHumiditiesByHiveAndDates(int hive, DateTime start, DateTime end)
        {
            return AddTypeFieldToCollectionOfModelData(
                _humidityData.Find(humidity =>
                        humidity.HiveId == hive && start <= humidity.DateTime && humidity.DateTime < end).ToList(),
                "humidities");
        }

        private List<DataModel> AddTypeFieldToCollectionOfModelData(List<DataModel> models, string type)
        {
            models.ForEach(model => model.Type = type);
            return models;
        }
    }
}