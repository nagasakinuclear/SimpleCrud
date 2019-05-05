using AutoMapper;
using SimpleCrud.Configuration.Contracts;
using SimpleCrud.Dtos.Configuration;

namespace SimpleCrud.Configuration
{
    public class Configuration : IConfiguration
    {
        public string ConnectionString { get; set; }

        public void LoadConfiguration(LoadConfigurationDto dto)
        {
            ConnectionString = dto.ConnectionString;
        }
    }
}
