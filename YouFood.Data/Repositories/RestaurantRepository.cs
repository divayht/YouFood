using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFood.Data.Context;
using YouFood.Data.Repositories.Base;
using YouFood.Domain.Model;

namespace YouFood.Data.Repositories
{
    public class RestaurantRepository : Repository<Restaurant, int, WebContext>
    {
        public RestaurantRepository()
        {
            //var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);
            var webContext = SharedObjectContext.Instance.Context;

            base.context = webContext;
            base.Entity = webContext.Restaurants;
        }
    }
}
