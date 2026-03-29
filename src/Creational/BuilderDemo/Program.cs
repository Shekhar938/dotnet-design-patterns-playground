using System;
using System.Collections.Generic;

namespace BuilderDemo
{
    // The Builder Pattern lets you construct complex objects step by step. 
    // The pattern allows you to produce different types and representations 
    // of an object using the same construction code.

    // The Product class is the result of the construction.
    public class Report
    {
        public string Header { get; set; } = string.Empty;
        public string Footer { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<string> Content { get; set; } = new List<string>();

        public void Display()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine("Content:");
            Content.ForEach(c => Console.WriteLine($"- {c}"));
            Console.WriteLine($"Footer: {Footer}");
            Console.WriteLine("----------------------------------\n");
        }
    }

    // The Builder interface specifies methods for creating the different 
    // parts of the Product objects.
    public interface IReportBuilder
    {
        IReportBuilder SetHeader(string header);
        IReportBuilder SetFooter(string footer);
        IReportBuilder SetTitle(string title);
        IReportBuilder AddContent(string content);
        Report Build();
    }

    // Concrete Builders implement the interface and provide specific 
    // implementations for the construction steps.
    public class PDFReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public IReportBuilder SetHeader(string header)
        {
            _report.Header = $"[PDF Header] {header}";
            return this;
        }

        public IReportBuilder SetFooter(string footer)
        {
            _report.Footer = $"[PDF Footer] {footer}";
            return this;
        }

        public IReportBuilder SetTitle(string title)
        {
            _report.Title = title.ToUpper();
            return this;
        }

        public IReportBuilder AddContent(string content)
        {
            _report.Content.Add($"PDF Encoded: {content}");
            return this;
        }

        public Report Build()
        {
            var result = _report;
            _report = new Report(); // Reset for next use
            return result;
        }
    }

    public class HTMLReportBuilder : IReportBuilder
    {
        private Report _report = new Report();

        public IReportBuilder SetHeader(string header)
        {
            _report.Header = $"<html><header>{header}</header>";
            return this;
        }

        public IReportBuilder SetFooter(string footer)
        {
            _report.Footer = $"<footer>{footer}</footer></html>";
            return this;
        }

        public IReportBuilder SetTitle(string title)
        {
            _report.Title = $"<h1>{title}</h1>";
            return this;
        }

        public IReportBuilder AddContent(string content)
        {
            _report.Content.Add($"<p>{content}</p>");
            return this;
        }

        public Report Build()
        {
            var result = _report;
            _report = new Report();
            return result;
        }
    }

    // The Director is only responsible for executing the building steps in a 
    // particular sequence. It is helpful when producing products according 
    // to a specific order or configuration.
    public class ReportDirector
    {
        public void CreateMonthlySales(IReportBuilder builder)
        {
            builder.SetTitle("Monthly Sales Report")
                   .SetHeader("Company Confidential")
                   .AddContent("Sales: $100,000")
                   .AddContent("Expenses: $50,000")
                   .AddContent("Profit: $50,000")
                   .SetFooter("Page 1 of 1");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Builder Pattern: Report Builder ---");

            var director = new ReportDirector();

            // Using PDF Builder
            Console.WriteLine("Building PDF Report...");
            var pdfBuilder = new PDFReportBuilder();
            director.CreateMonthlySales(pdfBuilder);
            var pdfReport = pdfBuilder.Build();
            pdfReport.Display();

            // Using HTML Builder
            Console.WriteLine("Building HTML Report...");
            var htmlBuilder = new HTMLReportBuilder();
            director.CreateMonthlySales(htmlBuilder);
            var htmlReport = htmlBuilder.Build();
            htmlReport.Display();
            
            // Custom construction without director
            Console.WriteLine("Building custom simple report...");
            var customReport = new PDFReportBuilder()
                .SetTitle("Quick Note")
                .AddContent("Just a quick reminder.")
                .Build();
            customReport.Display();
        }
    }
}
