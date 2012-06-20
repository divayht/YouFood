using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFood.Data.Repositories;
using YouFood.Domain.Model;

namespace YouFood.Services
{
    public class OrderService
    {
        private readonly OrderRepository repository;

        public OrderService()
        {
            repository = new OrderRepository();
        }

        public void AddOrder(Order order)
        {
            repository.Add(order);
            repository.SaveOrUpdate();
        }

        public List<Order> GetPendingOrders()
        {
            List<Order> orders = repository
                .Get(x => x.OrderState == OrderState.New)
                .Union(repository.Get(x => x.OrderState == OrderState.Cooking))
                .ToList();

            return orders;
        }

        public List<Order> GetReadyOrders()
        {
            List<Order> orders = repository.Get(x => x.OrderState == OrderState.ReadyToServe).ToList();

            return orders;
        }

        public void UpdateOrders(List<Order> orders )
        {
            foreach (var order in orders)
            {
                repository.Update(order);
            }
        }
    }
}
