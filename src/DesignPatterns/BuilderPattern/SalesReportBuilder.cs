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
        SalesReport Build();
    }

    // Budowniczy w wersji Fluent Api
    public class FluentSalesReportBuilder
    {
        private SalesReport salesReport;
        private IEnumerable<Order> orders;

        public FluentSalesReportBuilder(IEnumerable<Order> orders)
        {
            this.orders = orders;

            salesReport = new SalesReport();
        }

        public FluentSalesReportBuilder AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);

            return this;
        }

        public FluentSalesReportBuilder AddGenderSection()
        {
            salesReport.GenderDetails = orders
               .GroupBy(o => o.Customer.Gender)
               .Select(g => new GenderReportDetail(
                           g.Key,
                           g.Sum(x => x.Details.Sum(d => d.Quantity)),
                           g.Sum(x => x.Details.Sum(d => d.LineTotal))));

            return this;
        }

        public FluentSalesReportBuilder AddProductSection()
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
