using Interface;
using System.Collections.Generic;

namespace Model
{
    public class DataSale : IIdentifier
    {
        public string ID { get; set; }

        public string SaleID { get; set; }

        public List<Item> Itens { get; set; }

        public Salesman Salesman { get; set; }
    }
}
