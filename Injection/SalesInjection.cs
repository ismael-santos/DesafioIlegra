using Business;
using Interface.Injection;
using System.Collections.Generic;

namespace Injection
{
    public class SalesInjection : IServiceSales
    {
        private Sales _Sales = new Sales();

        private SalesInjection() { }

        public static IServiceSales Instance => new SalesInjection();

        public void SetTypeOfData(List<string> lines)
        {
            _Sales.SetTypeOfData(lines);
        }

        public string GetSalesReport()
        {
            return _Sales.GetSalesReport();
        }
    }
}
