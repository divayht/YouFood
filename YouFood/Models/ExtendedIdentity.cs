using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace YouFood.Models
{
    [Serializable]
    public class ExtendedIdentity : IIdentity
    {
        public FormsAuthenticationTicket Ticket { get; private set; }
        //public User User { get; private set; }
        public string Name { get; private set; }
        public int TableId { get; set; }

        public string AuthenticationType
        {
            get { return "YouFood"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public ExtendedIdentity(FormsAuthenticationTicket ticket)
        {
            //UserService service = new UserService(new UserRepository());
            //this.User = service.Get(ticket.UserData);

            this.Ticket = ticket;
            this.Name = ticket.Name;
            this.TableId = Convert.ToInt32(ticket.UserData);
        }
    }
}