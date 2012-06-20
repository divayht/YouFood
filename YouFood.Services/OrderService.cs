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
        private readonly OrderRepository orderRepository;

        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public void AddOrder(Order order)
        {
            orderRepository.Add(order);
        }

        public void UpdateState(int orderId, OrderState orderState)
        {
            Order order = orderRepository.Get(orderId);
            order.OrderState = orderState;
            orderRepository.SaveOrUpdate();
        }

        public List<Order> GetPendingOrders()
        {
            List<Order> orders = orderRepository
                .Get(x => x.OrderStateId == (int)OrderState.New)
                .Union(orderRepository.Get(x => x.OrderStateId == (int)OrderState.Cooking))
                .ToList();

            return orders;
        }

        public List<Order> GetReadyOrders()
        {
            List<Order> orders = orderRepository.Get(x => x.OrderStateId == (int)OrderState.ReadyToServe).ToList();

            return orders;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAll().ToList();
        }
    }
}
