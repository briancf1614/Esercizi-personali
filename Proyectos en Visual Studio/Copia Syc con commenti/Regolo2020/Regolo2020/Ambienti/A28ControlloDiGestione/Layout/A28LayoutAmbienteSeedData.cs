using Regolo2020.Ambienti.A00Strumenti.DataModels.Tables;
using Regolo2020.Ambienti.A28ControlloDiGestione.DataModels;
using Regolo2020.Base.DataModels;

namespace Regolo2020.Ambienti.A28ControlloDiGestione.Layout
{
    public class A28LayoutAmbienteSeedData : ILayoutAmbienteSeedData<A28ControlloDiGestioneDbContext>
    {
        public A000001AmbientiApplicativi GetAmbienteApplicativo()
        {
            throw new NotImplementedException();
        }

        public A000017LayoutAmbienti GetLayoutAmbiente()
        {
           throw new NotImplementedException();
        }

        // Next Step: Aggiungere pagine/tab ognuna una classe
    }
}
