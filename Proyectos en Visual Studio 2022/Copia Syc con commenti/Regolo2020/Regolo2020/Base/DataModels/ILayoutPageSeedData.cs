using Microsoft.EntityFrameworkCore;
using Regolo2020.Ambienti.A00Strumenti.DataModels.Tables;

namespace Regolo2020.Base.DataModels
{
    public interface ILayoutPageSeedData<TDbContext>
        where TDbContext : DbContext
    {
        A000018LayoutPage GetLayoutPage();
    }
}
