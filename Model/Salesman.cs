using Interface;

namespace Model
{
    public class Salesman : INaturalPerson
    {
        public string ID { get; set; }

        public string CPF{ get; set; }

        public string Name{ get; set; }

        public decimal Salary { get; set; }
    }
}
