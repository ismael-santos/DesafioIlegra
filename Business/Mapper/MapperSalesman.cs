using Interface.Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public class MapperSalesman : IMapper<string, Salesman>
    {
        private MapperSalesman() { }

        public static MapperSalesman Instance => new MapperSalesman();

        public Salesman Map(string @in)
        {
            List<string> salesmanData = @in.Split('ç').ToList();

            return new Salesman
            {
                ID = salesmanData[0],
                CPF = salesmanData[1],
                Name = salesmanData[2],
                Salary = Convert.ToDecimal(salesmanData[3].Replace(".", ",")) //Considerar as casas decimais
            };
        }
    }
}
