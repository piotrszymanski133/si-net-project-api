namespace si_net_project_api
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string TemperatureCollection { get; set; }
        string WindCollection { get; set; }
        string PressureCollection { get; set; }
        string HumidityCollection { get; set; }
    }
}