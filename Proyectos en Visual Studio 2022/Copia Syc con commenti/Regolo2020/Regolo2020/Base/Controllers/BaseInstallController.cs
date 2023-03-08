using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Regolo2020.Ambienti.A00Strumenti.DataModels.Tables;
using Regolo2020.Base.DataModels;

namespace Regolo2020.Base.Controllers
{
    [ApiController]
    [Route("Regolo2020/RestService/[controller]")]
    public class BaseInstallController<TDbContext> : ControllerBase
        where TDbContext : DbContext
    {
        private readonly TDbContext _ambienteDbContext;
        private readonly RegoloDbContext _dbContext;
        private readonly TransactionHelper _transactionHelper;
        private readonly ILayoutAmbienteSeedData<TDbContext> _layoutAmbienteSeedData;
        private readonly IEnumerable<ILayoutPageSeedData<TDbContext>> _allLayoutPageSeedData;

        public BaseInstallController(
            TDbContext ambienteDbContext,
            RegoloDbContext dbContext,
            TransactionHelper transactionHelper,
            ILayoutAmbienteSeedData<TDbContext> layoutAmbienteSeedData,
            IEnumerable<ILayoutPageSeedData<TDbContext>> allLayoutPageSeedData)
        {
            _ambienteDbContext = ambienteDbContext;
            _dbContext = dbContext;
            _transactionHelper = transactionHelper;
            _layoutAmbienteSeedData = layoutAmbienteSeedData;
            _allLayoutPageSeedData = allLayoutPageSeedData;
        }

        [HttpPut("Migrate")]
        public ActionResult Migrate()
        {
            _ambienteDbContext.Database.Migrate();
            return NoContent();
        }

        [HttpPut("CreateOrUpdateLayout")]
        public ActionResult CreateOrUpdateLayout()
        {
            var dbContextName = typeof(TDbContext).Name;
            var codiceAmbiente = dbContextName[..3];
            var nomeAmbiente = dbContextName.Replace(codiceAmbiente, string.Empty).Replace("DbContext", string.Empty);
            var nomeRisorsaSistema = "Ambiente" + nomeAmbiente;

            var ambiente = _dbContext.Set<A000001AmbientiApplicativi>().FirstOrDefault(a => a.CodiceAmbiente == codiceAmbiente);
            var oldLayoutAmbiente = _dbContext.Set<A000017LayoutAmbienti>().FirstOrDefault(la => la.Ambiente.CodiceAmbiente == codiceAmbiente);
            var risorsaSistemaAmbiente = _dbContext.Set<A000027RisorseSistema>().FirstOrDefault(rs => rs.NomeRisorsa == nomeRisorsaSistema);

            _transactionHelper.ExecuteWithinTransaction(() =>
            {
                // Creazione ambiente
                if (ambiente == null)
                {
                    ambiente = new A000001AmbientiApplicativi
                    {
                        CodiceAmbiente = codiceAmbiente,
                        Ambiente = nomeAmbiente,
                        Descrizione = nomeAmbiente,
                        Versione = 100,
                        UrlStart = $"<URLBASE>{codiceAmbiente}{nomeAmbiente}_{codiceAmbiente}9000{nomeAmbiente}/All"
                    };

                    _dbContext.Add(ambiente);

                    // Utile in quanto serve per avere a disposizione l'id dell'ambiente appena creato
                    _dbContext.SaveChanges();
                }

                // Eliminazione dei layout ambiente esistenti (L'ordine di eliminazione è determinante per far si che l'operazione vada a buon fine.
                if (oldLayoutAmbiente != null)
                {
                    _dbContext.Set<A000024LayoutDataGrid>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000025LayoutTreeView>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000029LayoutListView>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000031LayoutBlockView>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000022LayoutListeValori>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000021LayoutGroups>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000020LayoutDetail>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000019LayoutDetails>().Where(item => item.LayoutPage.LayoutAmbiente.Id == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000018LayoutPage>().Where(item => item.IdLayoutAmbiente == oldLayoutAmbiente.Id).ExecuteDelete();
                    _dbContext.Set<A000017LayoutAmbienti>().Remove(oldLayoutAmbiente);
                }

                // Creazione layout ambiente
                var layoutAbmiente = _layoutAmbienteSeedData.GetLayoutAmbiente();
                layoutAbmiente.IdAmbiente = ambiente.Id;

                // Creazione dei layout page ambiente
                layoutAbmiente.LayoutPage = _allLayoutPageSeedData
                    .Select(layoutPageSeedData =>
                    {
                        var layoutPage = layoutPageSeedData.GetLayoutPage();
                        layoutPage.TabName = Guid.NewGuid().ToString();
                        layoutPage.UrlTab = $"<URLBASE>{nomeAmbiente}_{codiceAmbiente}9000{nomeAmbiente}";
                        layoutPage.DetailsMaxPageRows = 10;

                        return layoutPage;
                    })
                    .ToList();

                _dbContext.Add(layoutAbmiente);

                // Creazione risorsa sistema per ambiente nel caso in cui non esiste
                if (risorsaSistemaAmbiente == null)
                {
                    risorsaSistemaAmbiente = new A000027RisorseSistema
                    {
                        NomeRisorsa = nomeRisorsaSistema,
                        Descrizione = nomeRisorsaSistema
                    };

                    _dbContext.Add(risorsaSistemaAmbiente);
                }
                else
                {
                    risorsaSistemaAmbiente.NomeRisorsa = nomeRisorsaSistema;
                    risorsaSistemaAmbiente.Descrizione = nomeRisorsaSistema;
                }

                _dbContext.SaveChanges();
            });

            return NoContent();
        }

        [HttpPut("CreateOrUpdateSeedData")]
        public ActionResult CreateOrUpdateSeedData()
        {
            // TODO: InsertOrUpdate dei dati di inizializzazione
            return NoContent();
        }
    }
}