﻿using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RefactoringKata
{
    public class Orders
    {
        [JsonProperty("orders")]
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public int GetOrdersCount()
        {
            return _orders.Count;
        }

        public Order GetOrder(int i)
        {
            return _orders[i];
        }
    }
}
