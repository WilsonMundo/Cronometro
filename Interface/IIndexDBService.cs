using Cronometro.Models;

namespace Cronometro.Interface
{
    public interface IIndexDBService
    {
        Task BulkCompetidor(CompetidorBD competidor);
        Task ConfigureDatabase();
        Task<List<Competidor>?> GetCompetidors();
    }
}
