using Interface.Mapper;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public class MapperClient : IMapper<string, Client>
    {
        private MapperClient() { }

        public static MapperClient Instance => new MapperClient();

        public Client Map(string @in)
        {
            List<string> clientData = @in.Split('ç').ToList();

            return new Client
            {
                ID = clientData[0],
                CNPJ = clientData[1],
                Name = clientData[2],
                BusinessArea = clientData[3]
            };
        }
    }
}
