using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    // Budowniczy w wersji Fluent Api
    public class FluentSalesReportBuilder : IFluentSalesReportBuilder
    {
        private SalesReport salesReport;
        private IEnumerable<Order> orders;

        public FluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;

            salesReport = new SalesReport();
        }

        public IFluentSalesReportBuilder AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public IFluentSalesReportBuilder AddGenderSection()
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
        }

        public IFluentSalesReportBuilder AddProductSection()
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        public SalesReport Build()
        {
            return salesReport;
        }
    }
}
