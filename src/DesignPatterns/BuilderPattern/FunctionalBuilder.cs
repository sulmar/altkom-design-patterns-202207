using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Leniwy budowniczy - wersja generyczna
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });

            return (TSelf)this;
        }

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));

    }

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
