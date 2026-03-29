using System;

namespace PrototypeDemo
{
    // The Prototype Pattern allows an object to produce a copy of itself. 
    // This is useful when the cost of creating a new object is higher 
    // than copying an existing one.

    // The Prototype interface declares the cloning method.
    public abstract class DocumentPrototype
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public DocumentPrototype(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public abstract DocumentPrototype Clone();

        public virtual void Display()
        {
            Console.WriteLine($"Document: {Title}, Content: {Content}");
        }
    }

    // Concrete Prototypes implement the cloning method.
    public class ReportTemplate : DocumentPrototype
    {
        public string Header { get; set; }

        public ReportTemplate(string title, string content, string header) 
            : base(title, content)
        {
            Header = header;
        }

        // Implementation of cloning - shallow copy
        public override DocumentPrototype Clone()
        {
            Console.WriteLine($"Cloning Report: {Title}");
            // MemberwiseClone creates a shallow copy
            return (DocumentPrototype)this.MemberwiseClone();
        }

        public override void Display()
        {
            Console.WriteLine($"[Report] Title: {Title}, Header: {Header}, Content: {Content}");
        }
    }

    public class InvoiceTemplate : DocumentPrototype
    {
        public double Amount { get; set; }

        public InvoiceTemplate(string title, string content, double amount) 
            : base(title, content)
        {
            Amount = amount;
        }

        public override DocumentPrototype Clone()
        {
            Console.WriteLine($"Cloning Invoice: {Title}");
            return (DocumentPrototype)this.MemberwiseClone();
        }

        public override void Display()
        {
            Console.WriteLine($"[Invoice] Title: {Title}, Amount: ${Amount:F2}, Content: {Content}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Prototype Pattern: Document Cloning ---");

            // 1. Create initial templates (Prototypes)
            var monthlyReport = new ReportTemplate("Monthly Sales", "Initial Data", "Company Header");
            var serviceInvoice = new InvoiceTemplate("Service Fee", "Basic Package", 150.00);

            // 2. Client needs a copy of the monthly report to customize
            var salesReportCopy = (ReportTemplate)monthlyReport.Clone();
            salesReportCopy.Title = "March 2024 Sales Report";
            salesReportCopy.Content = "Revenue: $1.2M";

            // 3. Client needs a copy of the invoice
            var customInvoice = (InvoiceTemplate)serviceInvoice.Clone();
            customInvoice.Title = "Custom Service Invoice";
            customInvoice.Amount = 2500.00;

            // Display results
            Console.WriteLine("\nOriginal Templates:");
            monthlyReport.Display();
            serviceInvoice.Display();

            Console.WriteLine("\nCloned and Modified Objects:");
            salesReportCopy.Display();
            customInvoice.Display();

            // Verify they are different instances
            if (!ReferenceEquals(monthlyReport, salesReportCopy))
            {
                Console.WriteLine("\nSuccess: Cloned report is a separate instance.");
            }
        }
    }
}
