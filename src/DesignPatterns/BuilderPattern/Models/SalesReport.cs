using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class SalesReport
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalSalesAmount { get; set; }

        public IEnumerable<ProductReportDetail> ProductDetails { get; set; }
        public IEnumerable<GenderReportDetail> GenderDetails { get; set; }

        public SalesReport()
        {
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("------------------------------");

            builder.AppendLine($"{Title} {CreateDate}");
            builder.AppendLine($"Total Sales Amount: {TotalSalesAmount:c2}");

            builder.AppendLine( "------------------------------");

            builder.AppendLine("Total By Products:");
            foreach (var detail in ProductDetails)
            {
                builder.AppendLine($"- {detail.Product.Name} {detail.Quantity} {detail.TotalAmount:c2}");
            }
            builder.AppendLine("Total By Gender:");
            foreach (var detail in GenderDetails)
            {
                builder.AppendLine($"- {detail.Gender} {detail.Quantity} {detail.TotalAmount:c2}");
            }

            return builder.ToString(); // -> Build()
        }
    }




}