﻿using Model;
using System.Collections.Generic;

namespace Busines_
{
    public class SalesEstruct
    {
        public List<Salesman> SalesmanList = new List<Salesman>();
        public List<Client> ClientList = new List<Client>();
        public List<DataSale> DataSaleList = new List<DataSale>();
        public string ErrorMessage;

        public static SalesEstruct Instance => new SalesEstruct();  

        private SalesEstruct() { }
    }
}
