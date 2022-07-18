﻿using BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Builder Pattern!");

            PhoneTest();

            LazyFluentSalesReportBuilderTest();

            // SalesReportTest();

            // PersonTest();
        }

        private static void PersonTest()
        {
            var person = new Person();
             
            person.Name = "Marcin";
            person.Position = "developer";
            person.AddSkill("C#");
            person.AddSkill("design-patterns");
            person.AddSkill("tdd");

            Console.WriteLine(person);
        }


        private static void LazyFluentSalesReportBuilderTest()
        {
            FakeOrdersService ordersService = new FakeOrdersService();
            IEnumerable<Order> orders = ordersService.Get();

            IFluentSalesReportBuilder salesReportBuilder = new LazyFluentSalesReportBuilder(orders);
            salesReportBuilder.AddHeader("Raport sprzedaży");
            salesReportBuilder.AddGenderSection();
            salesReportBuilder.AddProductSection();

            SalesReport salesReport = salesReportBuilder.Build();

            Console.WriteLine(salesReport);

        }

        private static void SalesReportTest()
        {
            FakeOrdersService ordersService = new FakeOrdersService();
            IEnumerable<Order> orders = ordersService.Get();

            ISalesReportBuilder salesReportBuilder = new SalesReportBuilder(orders);
            salesReportBuilder.AddHeader("Raport sprzedaży");
            salesReportBuilder.AddGenderSection();
            salesReportBuilder.AddProductSection();
            
            SalesReport salesReport = salesReportBuilder.Build();

            Console.WriteLine(salesReport);

        }

        private static void FluentSalesReportTest()
        {
            FakeOrdersService ordersService = new FakeOrdersService();
            IEnumerable<Order> orders = ordersService.Get();

            FluentSalesReportBuilder salesReportBuilder = new FluentSalesReportBuilder(orders);

            SalesReport salesReport = salesReportBuilder
                .AddHeader("Raport sprzedaży")
                .AddGenderSection()
                .AddProductSection()                
                .Build();
            
            Console.WriteLine(salesReport);

        }

        private static void PhoneTest()
        {
            Phone phone = new Phone();
            phone.Call("555999123", "555000321", ".NET Design Patterns");

            // Phone
            //  .Hangup()
            //  .From("555999123")
            //  .To("555000321")
            //  .To("555000322")
            //  .To("555000323")
            //  .WithSubject(".NET Design Patterns")
            //  .Call()
        }

        private static void FluentPhoneTest()
        {
            FluentPhone
                .HangUp()
                .From("555999123")
                .To("555000321")                                
                .To("555000322")
                .To("555000323")
                .WithSubject(".NET Design Patterns")
                .Call();
        }


    }

    public class FakeOrdersService
    {
        private readonly IList<Product> products;
        private readonly IList<Customer> customers;

        public FakeOrdersService()
            : this(CreateProducts(), CreateCustomers())
        {

        }

        public FakeOrdersService(IList<Product> products, IList<Customer> customers)
        {
            this.products = products;
            this.customers = customers;
        }

        private static IList<Customer> CreateCustomers()
        {
            return new List<Customer>
            {
                 new Customer("Anna", "Kowalska"),
                 new Customer("Jan", "Nowak"),
                 new Customer("John", "Smith"),
            };

        }

        private static IList<Product> CreateProducts()
        {
            return new List<Product>
            {
                new Product(1, "Książka C#", unitPrice: 100m),
                new Product(2, "Książka Praktyczne Wzorce projektowe w C#", unitPrice: 150m),
                new Product(3, "Zakładka do książki", unitPrice: 10m),
            };
        }

        public IEnumerable<Order> Get()
        {
            Order order1 = new Order(DateTime.Parse("2020-06-12 14:59"), customers[0]);
            order1.AddDetail(products[0], 2);
            order1.AddDetail(products[1], 2);
            order1.AddDetail(products[2], 3);

            yield return order1;

            Order order2 = new Order(DateTime.Parse("2020-06-12 14:59"), customers[1]);
            order2.AddDetail(products[0], 2);
            order2.AddDetail(products[1], 4);

            yield return order2;

            Order order3 = new Order(DateTime.Parse("2020-06-12 14:59"), customers[2]);
            order2.AddDetail(products[0], 2);
            order2.AddDetail(products[2], 5);

            yield return order3;


        }
    }




}