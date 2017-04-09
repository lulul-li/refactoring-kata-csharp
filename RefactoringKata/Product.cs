using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class Product
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        public string Code { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, Color color, Size size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }


        public void GenerateProduct(StringBuilder sb)
        {
            var productMappin = new Dictionary<string, object>()
            {
                {"code", Code},
                {"color", Color },
                {"size", Size },
                {"price", Price},
                {"currency",Currency}
            };
            if (Size == Size.SIZE_NOT_APPLICABLE)
            {
                productMappin.Remove("size");
            }

            sb.Append(productMappin.Aggregate("{",
                (current, item) => current + string.Format("\"{0}\": {1}, ", item.Key, item.Value is double ? item.Value : "\"" + item.Value + "\"")));

        }

    }
}
