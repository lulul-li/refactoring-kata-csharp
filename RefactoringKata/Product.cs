using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RefactoringKata
{
    public class Product
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("size")]
        public Size Size { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        private Dictionary<string, object> _productMappin;

        public bool ShouldSerializeSize()
        {
            return Size != Size.SIZE_NOT_APPLICABLE;
        }

        public Product(string code, Color color, Size size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }
    }
}
