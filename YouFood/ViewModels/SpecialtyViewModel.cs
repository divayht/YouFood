using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Helpers;

namespace YouFood.ViewModels
{
    public class SpecialtyViewModel
    {
        public List<SelectListItem> Specialties
        {
            get { return DropDownListHelper.Specialties; }
        }
    }
}