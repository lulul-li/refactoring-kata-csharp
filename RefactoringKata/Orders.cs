using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class Orders
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public string GenerateContent()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.Count; i++)
            {
                var order = _orders[i];
                sb.Append("{\"id\": ");
                sb.Append(order.GetOrderId());
                sb.Append(", \"products\": [");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    sb.Append(order.GetProduct(j).GenerateProduct());
                }
                RemoveLastCharacter(sb, order.GetProductsCount());

                sb.Append("]}, ");
            }

            RemoveLastCharacter(sb, _orders.Count);

            return sb.Append("]}").ToString();
        }

        private void RemoveLastCharacter(StringBuilder sb, int ordersCount)
        {
            if (ordersCount > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }
        }
    }
}
