using System.Text;
using Newtonsoft.Json;

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
            return JsonConvert.SerializeObject(_orders);
        }
    }
}