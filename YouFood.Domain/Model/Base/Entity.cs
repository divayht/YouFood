using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouFood.Domain.Model.Base
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; set; }
    }
}
