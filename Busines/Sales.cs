using Busines_.Properties;
using Interface.Injection;
using Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Business
{
    public class Sales : IServiceSales
    {
        private List<Salesman> SalesmanList = new List<Salesman>();
        private List<Client> ClientList = new List<Client>();
        private List<DataSale> DataSaleList = new List<DataSale>();

        public void SetTypeOfData(List<string> lines)
        {
            lines.ForEach(line => SetTypeOfDataLine(line));
        }

        private void SetTypeOfDataLine(string line)
        {
            string identifier = line.Split('ç')[0];

            TypeOfDataEnum typeOfData = EnumExtensions.GetEnumFromDescription<TypeOfDataEnum>(identifier);

            switch (typeOfData)
            {
                case TypeOfDataEnum.Salesman:
                    SalesmanList.Add(MapperSalesman.Instance.Map(line));
                    break;
                case TypeOfDataEnum.Client:
                    ClientList.Add(MapperClient.Instance.Map(line));
                    break;
                case TypeOfDataEnum.DataSale:
                    DataSaleList.Add(MapperDataSale.Instance.Map(line));
                    break;
            }
        }

        private int GetCountOfClients()
        {
            return ClientList.Count;
        }

        private int GetCountOfSalesman()
        {
            return SalesmanList.Count;
        }

        private string GetIdSaleMoreExpensive()
        {
            return DataSaleList
                    .OrderByDescending(x => x.Itens.Sum(y => y.Price))
                    .Select(x => x.SaleID)
                    .FirstOrDefault();
        }

        private string GetWorstSeller()
        {
            return DataSaleList
                    .OrderBy(x => x.Itens.Sum(y => y.Price))
                    .Select(x => x.Salesman.Name)
                    .FirstOrDefault();
        }

        public string GetSalesReport()
        {
            string countOfClients = string.Format(Resource.LogCountOfClients, GetCountOfClients());
            string countOfSalesman = string.Format(Resource.LogCountOfSalesman, GetCountOfSalesman());
            string saleMoreExpensive = string.Format(Resource.LogIdSaleMoreExpensive, GetIdSaleMoreExpensive());
            string worstSeller = string.Format(Resource.LogWorstSeller, GetWorstSeller());

            return string.Concat(countOfClients, Environment.NewLine,
                                 countOfSalesman, Environment.NewLine,
                                 saleMoreExpensive, Environment.NewLine,
                                 worstSeller);
        }
    }
}
