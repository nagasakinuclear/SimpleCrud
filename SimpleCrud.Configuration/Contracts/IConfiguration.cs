using SimpleCrud.Dtos.Configuration;


namespace SimpleCrud.Configuration.Contracts
{
    public interface IConfiguration
    {
        string ConnectionString { get; set; }
        string ProviderName { get; set; }

        void LoadConfiguration(LoadConfigurationDto dto);
    }
}
