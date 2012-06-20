using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YouFood.Data.Context
{
    //public enum ContextType
    //{
    //    WebContext
    //}

    //public static class ContextFactory
    //{
    //    public static object CreateContext(ContextType contextType)
    //    {
    //        switch (contextType)
    //        {
    //            case ContextType.WebContext:
    //                return new WebContext(ConfigurationManager.ConnectionStrings["WebContext"].ConnectionString);
    //            default:
    //                throw new Exception("Invalid context type");
    //        }
    //    }
    //}

    public class SharedObjectContext
    {
        private readonly WebContext context;

        private static readonly SharedObjectContext instance = new SharedObjectContext();

        private SharedObjectContext()
        {
            // Create the ObjectContext.
            context = new WebContext(ConfigurationManager.ConnectionStrings["WebContext"].ConnectionString);
        }

        // Return the single instance of the ClientSessionManager type.
        public static SharedObjectContext Instance
        {
            get
            {
                return instance;
            }
        }

        public WebContext Context
        {
            get
            {
                return context;
            }
        }
    }
}
