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
        private readonly DishRepository dishRepository = new DishRepository();

        public Menu GetCurrentMenu()
        {
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

        public Specialty GetSpecialty(int id)
        {
            SpecialtyRepository specialtyRepository = new SpecialtyRepository();
            Specialty specialty = specialtyRepository.Get(id);

            return specialty;
        }

        public void SetSpecialty(int id)
        {
            SpecialtyRepository specialtyRepository = new SpecialtyRepository();

            Specialty currentSpecialty = GetCurrentSpecialty();
            currentSpecialty.IsActive = false;

            Specialty specialty = specialtyRepository.Get(id);
            specialty.IsActive = true;

            specialtyRepository.SaveOrUpdate();
        }

        public void AddSpecialty(Specialty specialty)
        {
            SpecialtyRepository specialtyRepository = new SpecialtyRepository();
            specialtyRepository.Add(specialty);
        }

        public Dish GetDish(int dishId)
        {
            Dish dish = dishRepository.Get(dishId);
            return dish;
        }

        public List<Dish> GetAllDishes()
        {
            List<Dish> dishes = dishRepository.GetAll().ToList();

            return dishes;
        }
    }
}
