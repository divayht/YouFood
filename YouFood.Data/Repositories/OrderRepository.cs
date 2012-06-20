using YouFood.Data.Context;
using YouFood.Domain.Model;
using YouFood.Data.Repositories.Base;

namespace YouFood.Data.Repositories
{
    public class OrderRepository : Repository<Order, int, WebContext>
    {
        public OrderRepository()
        {
            //var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);
            var webContext = SharedObjectContext.Instance.Context;

            base.context = webContext;
            base.Entity = webContext.Orders;
        }
    }
}