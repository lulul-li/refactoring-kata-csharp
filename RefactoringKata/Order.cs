using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();
        private readonly FormateCommon _formateCommon;

        public Order(int id)
        {
            this.id = id;
            _formateCommon=new FormateCommon();
        }

        public int GetOrderId()
        {
            return id;
        }

        public int GetProductsCount()
        {
            return _products.Count;
        }

        public Product GetProduct(int j)
        {
            return _products[j];
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void GenerateOrder(StringBuilder sb)
        {
            sb.Append("{\"id\": ");
            sb.Append(GetOrderId());
            sb.Append(", \"products\": [");

            for (var j = 0; j < GetProductsCount(); j++)
            {
                GetProduct(j).GenerateProduct(sb);
                _formateCommon.RemoveLastCharacter(sb, GetProductsCount());
                sb.Append("}, ");
            }
            _formateCommon.RemoveLastCharacter(sb, GetProductsCount());

            sb.Append("]}, ");
        }
    }
}