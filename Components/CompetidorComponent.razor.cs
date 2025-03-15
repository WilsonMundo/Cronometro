using Cronometro.Models;
using Radzen;

namespace Cronometro.Components
{
    public partial class CompetidorComponent
    {
        private CompetidorBD competidor = new CompetidorBD();
        private List<Competidor> competidors = new List<Competidor>();  
        private bool guardando = false;
        private async Task CargarCompetidores()
        {
            competidors = await IndexDB.GetCompetidors()?? new List<Competidor>();
        }
        private async Task GuardarCompetidor(CompetidorBD competidor)
        {
            try
            {
                await IndexDB.BulkCompetidor(competidor);
                guardando = !guardando;
                ShowNotification(new NotificationMessage
                {
                    Style = "display:flex;width:100%;justify-content: center;",
                    Severity = NotificationSeverity.Info,
                    Summary = "Info",
                    Detail = "Registrado con exito",
                    Duration = 1000
                });
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage
                {
                    Style = "display:flex;width:100%;justify-content: center;",
                    Severity = NotificationSeverity.Error,
                    Summary = "Error",
                    Detail = ex.Message,
                    Duration = 30000
                });
                guardando = !guardando;
            }
            guardando = !guardando;
            competidor = new CompetidorBD();
            await CargarCompetidores();
        }
        private void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);

        }
        protected override async Task OnInitializedAsync()
        {
            await CargarCompetidores();
        }
    }
}
