using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Helpers;

namespace YouFood.ViewModels
{
    public class LogOnViewModel
    {
        public List<SelectListItem> Zones
        {
            get
            {
                return DropDownListHelper.Zones;
            }
        }
        public List<SelectListItem> Tables
        {
            get
            {
                return DropDownListHelper.Tables;
            }
        }
    }
}