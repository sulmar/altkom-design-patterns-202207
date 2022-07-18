using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class SalesReportFunctionalBuilder : FunctionalBuilder<SalesReport, SalesReportFunctionalBuilder>
    {
        private IEnumerable<Order> orders;

        public SalesReportFunctionalBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;
        }

        public SalesReportFunctionalBuilder AddHeader(string title) => Do(p => p.Title = title);

        public SalesReportFunctionalBuilder AddGenderSection() => Do(p => AddGenderSection(p));

        private SalesReportFunctionalBuilder AddGenderSection(SalesReport salesReport)
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
        }
    }
}
