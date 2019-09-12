using Interface;

namespace Model
{
    public class Client : IlegalPerson
    {
        public string ID { get; set; }
            
        public string CNPJ { get; set; }
            
        public string Name { get; set; }
            
        public string BusinessArea { get; set; }
    }
}
