using YouFood.Data.Context;
using YouFood.Domain.Model;
using YouFood.Data.Repositories.Base;

namespace YouFood.Data.Repositories
{
    public class MenuRepository : Repository<Menu, int, WebContext>
    {
        public MenuRepository()
        {
            //var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);
            var webContext = SharedObjectContext.Instance.Context;

            base.context = webContext;
            base.Entity = webContext.Menus;
        }
    }
}