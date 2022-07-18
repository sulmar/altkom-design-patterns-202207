using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class LazyFluentSalesReportBuilder : IFluentSalesReportBuilder
    {
        private List<Func<SalesReport, SalesReport>> actions = new List<Func<SalesReport, SalesReport>>();
        private IEnumerable<Order> orders;

        public LazyFluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;
        }

        public IFluentSalesReportBuilder AddHeader(string title)
        {
            return AddAction(p => AddHeader( p, title));
        }

        private IFluentSalesReportBuilder AddHeader(SalesReport salesReport, string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public IFluentSalesReportBuilder AddGenderSection()
        {
            return AddAction(p => AddGenderSection(p));
        }

        private IFluentSalesReportBuilder AddGenderSection(SalesReport salesReport)
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
            return AddAction(p => AddProductSection(p));
        }

        private IFluentSalesReportBuilder AddProductSection(SalesReport salesReport)
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));

            return this;
        }

        private IFluentSalesReportBuilder AddAction(Action<SalesReport> action)
        {
            actions.Add(p => { action(p); return p; });

            return this;
        }

        //public SalesReport Build()
        //{
        //    SalesReport salesReport = new SalesReport(); // akumulator

        //    foreach (var action in actions)
        //    {
        //        action.Invoke(salesReport);
        //    }

        //    return salesReport;
        //}

        public SalesReport Build() => actions.Aggregate(new SalesReport(), (p, action) => action(p));
    }
}
