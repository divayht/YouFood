using YouFood.Data.Context;
using YouFood.Data.Repositories.Base;
using YouFood.Domain.Model;

namespace YouFood.Data.Repositories
{
    public class DishRepository : Repository<Dish, int, WebContext>
    {
        public DishRepository()
        {
            //var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);
            var webContext = SharedObjectContext.Instance.Context;

            base.context = webContext;
            base.Entity = webContext.Dishes;
        }
    }
}
