using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Domain.Model;
using YouFood.Helpers;

namespace YouFood.ViewModels
{
    public class AddDishViewModel
    {
        public List<SelectListItem> Specialties
        {
            get { return DropDownListHelper.Specialties; }
        }

        public List<SelectListItem> DishesType
        {
            get { return DropDownListHelper.DishesType; }
        }
    }
}