using YouFood.Data.Context;
using YouFood.Domain.Model;
using YouFood.Data.Repositories.Base;

namespace YouFood.Data.Repositories
{
    public class ZoneRepository : Repository<Zone, int, WebContext>
    {
        public ZoneRepository()
        {
            var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);

            base.context = webContext;
            base.Entity = webContext.Zones;
        }
    }
}
