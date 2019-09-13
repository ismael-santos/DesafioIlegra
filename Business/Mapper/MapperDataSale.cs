using Interface.Mapper;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public class MapperDataSale : IMapper<string, DataSale>
    {
        private MapperDataSale() { }

        public static MapperDataSale Instance => new MapperDataSale();

        public DataSale Map(string @in)
        {
            List<string> dataSale = @in.Split('ç').ToList();

            return new DataSale
            {
                ID = dataSale[0],
                SaleID = dataSale[1],
                Itens = MapperItem.Instance.Map(dataSale[2]),
                Salesman = new Salesman { Name = dataSale[3] }
            };
        }
    }
}
