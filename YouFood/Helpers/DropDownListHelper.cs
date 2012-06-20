using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Data.Repositories;
using YouFood.Domain.Model;

namespace YouFood.Helpers
{
    public static class DropDownListHelper
    {
        public static List<SelectListItem> Zones
        {
            get
            {
                ZoneRepository zoneRepository = new ZoneRepository();

                return zoneRepository.GetAll().AsEnumerable().Select(zone => new SelectListItem
                {
                    Selected = false,
                    Text = zone.Name,
                    Value = zone.Id.ToString()
                }).OrderBy(g => g.Text).ToList();
            }
        }

        public static List<SelectListItem> Tables
        {
            get
            {
                TableRepository tableRepository = new TableRepository();

                return tableRepository.GetAll().AsEnumerable().Select(table => new SelectListItem
                {
                    Selected = false,
                    Text = table.Id.ToString(),
                    Value = table.Id.ToString()
                }).OrderBy(g => g.Text).ToList();
            }
        }

        public static List<SelectListItem> Specialties
        {
            get
            {
                SpecialtyRepository specialtyRepository = new SpecialtyRepository();

                return specialtyRepository.GetAll().AsEnumerable().Select(specialty => new SelectListItem
                {
                    Selected = specialty.IsActive,
                    Text = specialty.Name,
                    Value = specialty.Id.ToString()
                }).OrderBy(g => g.Text).ToList();
            }
        }

        public static List<SelectListItem> DishesType
        {
            get
            {
                return EnumHelper.GetValues<DishType>().Select(dishType => new SelectListItem
                {
                    Selected = false,
                    Text = dishType.ToString(),
                    Value = ((int) dishType).ToString()
                }).OrderBy(g => g.Text).ToList();

            }
        }
    }
}