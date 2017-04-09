using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;
        private readonly FormateCommon _formateCommon;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
            _formateCommon = new FormateCommon();
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                _orders.GetOrder(i).GenerateOrder(sb);
            }

            _formateCommon.RemoveLastCharacter(sb, _orders.GetOrdersCount());

            return sb.Append("]}").ToString();
        }
    }
}