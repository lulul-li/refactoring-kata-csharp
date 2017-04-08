using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class Product
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        public string Code { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        private Dictionary<int, string> _size = new Dictionary<int, string>()
        {
            {-1, "Invalid Size"},
            {1, "XS"},
            {2, "S"},
            {3, "M"},
            {4, "L"},
            {5, "XL"},
            {6, "XXL"},
        };

        private Dictionary<int, string> _color = new Dictionary<int, string>()
        {
            {-1, "no color"},
            {1, "blue"},
            {2, "red"},
            {3, "yellow"}
        };

        public string GenerateProduct()
        {
            var productMappin = new Dictionary<string, string>()
            {
                {"code", "\"" + Code + "\""},
                {"color", "\"" + _color[Color] + "\""},
                {"size", "\"" + _size[Size] + "\""},
                {"price", Price.ToString()},
                {"currency", "\"" + Currency + "\""}
            };
            if (Size == SIZE_NOT_APPLICABLE)
            {
                productMappin.Remove("size");
            }
            var sbProd = productMappin.Aggregate("{",
                (current, item) => current + string.Format("\"{0}\": {1}, ", item.Key, item.Value));

            return sbProd.Substring(0,sbProd.Length-2) + "}, ";
        }
    }
}
