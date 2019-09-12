using System.Collections.Generic;

namespace Interface.Injection
{
    public interface IServiceSales
    {
        void SetTypeOfData(List<string> lines);
        string GetSalesReport();
    }
}
