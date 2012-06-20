using YouFood.Data.Context;
using YouFood.Data.Repositories.Base;
using YouFood.Domain.Model;

namespace YouFood.Data.Repositories
{
    public class DishRepository : Repository<Dish, int, WebContext>
    {
        public DishRepository()
        {
            var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);

            base.context = webContext;
            base.Entity = webContext.Dishes;
        }
    }
}
