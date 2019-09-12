using Business;
using Interface.Injection;
using System.Collections.Generic;

namespace Injection
{
    public class SalesInjection : IServiceSales
    {
        private Sales _Sales = new Sales();

        private SalesInjection(List<string> lines)
        {
            SetTypeOfData(lines);
        }

        public static SalesInjection Instance(List<string> lines) =>
            new SalesInjection(lines);

        public string GetSalesReport()
        {
            return _Sales.GetSalesReport();
        }

        public void SetTypeOfData(List<string> lines)
        {
            _Sales.SetTypeOfData(lines);
        }
    }
}
