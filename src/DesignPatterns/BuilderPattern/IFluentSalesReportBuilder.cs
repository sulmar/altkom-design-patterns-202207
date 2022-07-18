namespace BuilderPattern
{
    public interface IFluentSalesReportBuilder
    {
        IFluentSalesReportBuilder AddHeader(string title);
        IFluentSalesReportBuilder AddGenderSection();
        IFluentSalesReportBuilder AddProductSection();

        SalesReport Build();

    }
}
