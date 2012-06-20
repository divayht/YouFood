using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouFood.Domain.Model;

namespace YouFood.Models
{
    public class Cart
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Dish dish, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(x => x.Dish.Id == dish.Id);

            if (line == null)
            {
                lineCollection.Add(new CartLine { Dish = dish, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public CartLine Get(Dish dish)
        {
            return lineCollection.SingleOrDefault(x => x.Dish.Id == dish.Id);
        }

        public void RemoveLine(Dish dish)
        {
            lineCollection.RemoveAll(x => x.Dish.Id == dish.Id);
        }

        public double ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Dish.Price * x.Quantity);
        }

        public double ComputeTaxes()
        {
            return ComputeTotalValue()*7.7/100;
        }

        public double ComputeTotalValueWithTaxes()
        {
            return ComputeTotalValue() + ComputeTaxes();
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IList<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public bool Contains(Dish dish)
        {
            List<CartLine> lines = Lines.Where(x => x.Dish.Id == dish.Id).ToList();
            bool result = lines.Any();

            return result;
        }
    }
}