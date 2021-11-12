namespace si_net_project_api
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TemperatureCollection { get; set; }
        public string WindCollection { get; set; }
        public string PressureCollection { get; set; }
        public string HumidityCollection { get; set; }
    }
}