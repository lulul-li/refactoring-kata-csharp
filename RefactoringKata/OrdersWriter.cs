using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                sb.Append(_orders.GetOrder(i).GenerateOrder());
            }

            if (_orders.GetOrdersCount() > 0)
            {
                JsonConvert.RemoveLastCharacter(sb);
            }

            return sb.Append("]}").ToString();
        }
    }
}