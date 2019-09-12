using Model;
using System.Collections.Generic;

namespace Busines_
{
    public class SalesEstruct
    {
        public List<Salesman> SalesmanList = new List<Salesman>();
        public List<Client> ClientList = new List<Client>();
        public List<DataSale> DataSaleList = new List<DataSale>();
        public List<string> ErrorMessage = new List<string>();

        public static SalesEstruct Instance => new SalesEstruct();  

        private SalesEstruct() { }
    }
}
