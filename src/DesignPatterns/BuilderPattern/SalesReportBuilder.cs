using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Abstract builder
    public interface ISalesReportBuilder
    {
        void AddHeader(string title);
        void AddGenderSection();
        void AddProductSection();

        // Product
        SalesReport Build();
    }

    public interface IFluentSalesReportBuilder
    {
        IFluentSalesReportBuilder AddHeader(string title);
        IFluentSalesReportBuilder AddGenderSection();
        IFluentSalesReportBuilder AddProductSection();

        SalesReport Build();

    }

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
            // salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

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

        public SalesReport Build()
        {
            SalesReport salesReport = new SalesReport(); // akumulator

            foreach (var action in actions)
            {
                action.Invoke(salesReport);
            }

            return salesReport;
        }

        // public SalesReport Build() => actions.Aggregate(new SalesReport(), (salesReport, Func<SalesReport, SalesReport> action) => action(salesReport));
    }

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

    // Concrete builder
    public class SalesReportBuilder : ISalesReportBuilder
    {
        private SalesReport salesReport;
        private IEnumerable<Order> orders;

        public SalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;

            salesReport = new SalesReport();            
        }

        public void AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);
        }

        public void AddGenderSection()
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));
        }

        public void AddProductSection()
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));
        }


        public SalesReport Build()
        {
            return salesReport;
        }
    }
}
