using Busines_;
using Busines_.Properties;
using Interface.Injection;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Business
{
    public class Sales : IServiceSales
    {
        private SalesEstruct _SalesEstruct = SalesEstruct.Instance;

        public void SetTypeOfData(List<string> lines)
        {
            lines.ForEach(line => 
            {
                try
                {
                    SetTypeOfDataLine(line);
                }
                catch
                {
                    SetErrorMessage(line);
                }
            });
        }

        private void SetTypeOfDataLine(string line)
        {
            string identifier = line.Split('ç')[0];

            TypeOfDataEnum typeOfData = EnumExtensions.GetEnumFromDescription<TypeOfDataEnum>(identifier);

            switch (typeOfData)
            {
                case TypeOfDataEnum.Salesman:
                    _SalesEstruct.SalesmanList.Add(MapperSalesman.Instance.Map(line));
                    break;
                case TypeOfDataEnum.Client:
                    _SalesEstruct.ClientList.Add(MapperClient.Instance.Map(line));
                    break;
                case TypeOfDataEnum.DataSale:
                    _SalesEstruct.DataSaleList.Add(MapperDataSale.Instance.Map(line));
                    break;
            }
        }

        private void SetErrorMessage(string line)
        {
            _SalesEstruct.ErrorMessage.Add(string.Format(Resource.LogErrorMessage, line));
        }

        private int GetCountOfClients()
        {
            return _SalesEstruct.ClientList.Count;
        }

        private int GetCountOfSalesman()
        {
            return _SalesEstruct.SalesmanList.Count;
        }

        private string GetIdSaleMoreExpensive()
        {
            return _SalesEstruct.DataSaleList
                    .OrderByDescending(x => x.Itens.Sum(y => y.Price))
                    .Select(x => x.SaleID)
                    .FirstOrDefault();
        }

        private string GetWorstSeller()
        {
            return _SalesEstruct.DataSaleList
                    .OrderBy(x => x.Itens.Sum(y => y.Price))
                    .Select(x => x.Salesman.Name)
                    .FirstOrDefault();
        }

        private string GetErrorReport()
        {
            if (_SalesEstruct.ErrorMessage.Any())
            {
                return _SalesEstruct.ErrorMessage
                            .Aggregate((error, errorLine) =>
                                string.Concat(error, Environment.NewLine, errorLine));

            }

            return string.Empty;
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
                                 worstSeller, Environment.NewLine,
                                 GetErrorReport());
        }
    }
}
