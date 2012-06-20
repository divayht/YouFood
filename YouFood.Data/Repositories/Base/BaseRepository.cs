using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouFood.Data.Repositories.Base
{
    public class BaseRepository<TContext>
    {
        protected TContext context;
    }
}
