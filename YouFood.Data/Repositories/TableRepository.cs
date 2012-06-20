using YouFood.Data.Context;
using YouFood.Domain.Model;
using YouFood.Data.Repositories.Base;

namespace YouFood.Data.Repositories
{
    public class TableRepository : Repository<Table, int, WebContext>
    {
        public TableRepository()
        {
            var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);

            base.context = webContext;
            base.Entity = webContext.Tables;
        }
    }
}
