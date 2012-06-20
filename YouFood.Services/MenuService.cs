using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFood.Domain.Model;
using YouFood.Data.Repositories;

namespace YouFood.Services
{
    public class MenuService
    {
        //for several menus
        //public List<Menu> GetAvailableMenus()
        //{
        //    MenuRepository menuRepository = new MenuRepository();
        //    Specialty currentSpecialty = GetCurrentSpecialty();

        //    List<Menu> availableMenus = menuRepository.Get(x => x.SpecialtyId == currentSpecialty.Id).ToList();

        //    return availableMenus;
        //}

        public Menu GetCurrentMenu()
        {
            DishRepository dishRepository = new DishRepository();

            Specialty currentSpecialty = GetCurrentSpecialty();

            List<Dish> availableDishes = dishRepository.Get(x => x.SpecialtyId == currentSpecialty.Id).ToList();
            Menu menu = new Menu()
            {
                Specialty = currentSpecialty,
                Dishes = availableDishes
            };

            return menu;
        }

        public Specialty GetCurrentSpecialty()
        {
            SpecialtyRepository specialtyRepository = new SpecialtyRepository();
            Specialty currentSpecialty = specialtyRepository.Get(x => x.IsActive == true).Single();

            return currentSpecialty;
        }
    }
}
