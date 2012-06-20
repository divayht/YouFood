using YouFood.Data.Context;
using YouFood.Data.Repositories.Base;
using YouFood.Domain.Model;

namespace YouFood.Data.Repositories
{
    public class CorporateRepository : Repository<Corporate, int, WebContext>
    {
        public CorporateRepository()
        {
            var webContext = (WebContext) ContextFactory.CreateContext(ContextType.WebContext);

            base.context = webContext;
            base.Entity = webContext.Corporates;
        }
    }
}
