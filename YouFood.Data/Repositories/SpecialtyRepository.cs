using YouFood.Data.Context;
using YouFood.Domain.Model;
using YouFood.Data.Repositories.Base;

namespace YouFood.Data.Repositories
{
    public class SpecialtyRepository : Repository<Specialty, int, WebContext>
    {
        public SpecialtyRepository()
        {
            var webContext = (WebContext)ContextFactory.CreateContext(ContextType.WebContext);

            base.context = webContext;
            base.Entity = webContext.Specialties;
        }
    }
}