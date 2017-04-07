using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;
        private Dictionary<int, string> _size = new Dictionary<int, string>()
        {
            {-1,"Invalid Size"},
            {1,"XS"},
            {2,"S"},
            {3,"M"},
            {4,"L"},
            {5,"XL"},
            {6,"XXL"},
        };
        private Dictionary<int, string> _color = new Dictionary<int, string>()
        {
            {-1,"no color"},
            { 1,"blue"},
            { 2,"red"},
            { 3,"yellow"}
        };

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {

            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                sb.Append("{\"id\": ");
                sb.Append(order.GetOrderId());
                sb.Append(", \"products\": [");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    sb.Append(GenerateProduct(order.GetProduct(j)));
                    RemoveLastCharacter(sb, _orders.GetOrdersCount());
                    sb.Append("}, ");
                }
                RemoveLastCharacter(sb, order.GetProductsCount());

                sb.Append("]}, ");
            }

            RemoveLastCharacter(sb, _orders.GetOrdersCount());

            return sb.Append("]}").ToString();
        }

        private string GenerateProduct(Product product)
        {
            var productMappin = new Dictionary<string, string>()
            {
                {"code","\""+product.Code+"\""},
                {"color","\""+_color[product.Color]+"\""},
                {"size", "\"" + _size[product.Size]+"\""},
                {"price",product.Price.ToString()},
                {"currency","\""+product.Currency+"\""}
            };
            if (product.Size == Product.SIZE_NOT_APPLICABLE)
            {
                productMappin.Remove("size");
            }

            return productMappin.Aggregate("{", (current, item) => current + string.Format("\"{0}\": {1}, ", item.Key, item.Value));

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