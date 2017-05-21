using System.Collections.Generic;
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
        private Dictionary<string, object> _productMappin;

        public Product(string code, Color color, Size size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
            _productMappin = new Dictionary<string, object>()
            {
                {"code", Code},
                {"color", Color },
                {"size", Size },
                {"price", Price},
                {"currency",Currency}
            };
            if (Size == Size.SIZE_NOT_APPLICABLE)
            {
                _productMappin.Remove("size");
            }
        }


        public string GenerateProduct()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            foreach (var item in _productMappin)
            {
                sb.Append(JsonConvert.JasonString(item.Key, item.Value));
            }
            JsonConvert.RemoveLastCharacter(sb);
            sb.Append("}, ");
            return sb.ToString();
        }
    }
}
