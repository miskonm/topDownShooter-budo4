namespace TDS.Infrastructure.Persistant
{
    public interface IPersistantService : IService
    {
        PersistantData Data { get; }

        void Bootstrap();
        void Save();
    }
}