using Interface;

namespace Model
{
    public class Item : IIdentifier
    {
        public string ID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
