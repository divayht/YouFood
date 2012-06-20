using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class User : Entity<int>
    {
        public string Name{ get; set; }
        public string Password{ get; set; }

        public int? TableId { get; set; }
        public virtual Table Table { get; set; }
    }
}
