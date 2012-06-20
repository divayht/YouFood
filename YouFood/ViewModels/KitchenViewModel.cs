using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouFood.Domain.Model;

namespace YouFood.ViewModels
{
    public class KitchenViewModel
    {
        public List<Order> Cooking{ get; set; }
        public List<Order> Free { get; set; }

        public KitchenViewModel(List<Order> orders )
        {
            Cooking = orders.Where(x => x.OrderStateId == (int)OrderState.Cooking).ToList();
            Free = orders.Where(x => x.OrderStateId == (int)OrderState.New).ToList();
        }
    }
}