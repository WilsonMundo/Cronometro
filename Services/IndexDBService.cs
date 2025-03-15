
using Cronometro.Interface;
using Cronometro.Models;
using Microsoft.JSInterop;

namespace Cronometro.Services
{
    public class IndexDBService : IAsyncDisposable, IIndexDBService
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        
        public IndexDBService(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "/BD.js").AsTask());            
        }
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
        public async Task BulkCompetidor(CompetidorBD competidor)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("insertOrUpdateCompetidor", competidor);
        }
        public async Task ConfigureDatabase()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setupIndexedDB");
        }
        public async Task<List<Competidor>?> GetCompetidors()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Competidor>?>("getAllCompetidores");
        }
    }
}
