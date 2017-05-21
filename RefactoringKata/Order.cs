using System.Collections.Generic;
using System.Text;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            this.id = id;
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

        public string GenerateOrder()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append(JsonConvert.JasonString("id", GetOrderId()));
            sb.Append(GenerateProduct());
            sb.Append("]}, ");
            return sb.ToString();
        }

        private string GenerateProduct()
        {
            var sb = new StringBuilder();
            sb.Append("\"products\": [");
            for (var j = 0; j < GetProductsCount(); j++)
            {
                sb.Append(GetProduct(j).GenerateProduct());
            }
            if (GetProductsCount() > 0)
            {
               JsonConvert.RemoveLastCharacter(sb);
            }
            return sb.ToString();
        }
    }
}