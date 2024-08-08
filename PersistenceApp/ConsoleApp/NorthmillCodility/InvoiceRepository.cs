using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleApp.NorthmillCodility
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IQueryable<Invoice> _invoices;

        public InvoiceRepository(IQueryable<Invoice> invoices)
        {
            _invoices = invoices ?? throw new ArgumentNullException(nameof(invoices), "Invoices cannot be null.");
        }


        public decimal? GetTotal(int invoiceId)
        {
            var invoice = _invoices.FirstOrDefault(inv => inv.Id == invoiceId);
            return invoice?.InvoiceItems.Sum(item => item.Count * item.Price);
        }


        public decimal GetTotalOfUnpaid()
        {
            var unpaidInvoices = _invoices.Where(inv => !inv.AcceptanceDate.HasValue);
            return unpaidInvoices.Sum(inv => inv.InvoiceItems.Sum(item => item.Count * item.Price));
        }


        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            var query = _invoices.AsQueryable();

            if (from.HasValue)
            {
                query = query.Where(inv => inv.CreationDate >= from.Value);
            }

            if (to.HasValue)
            {
                query = query.Where(inv => inv.CreationDate <= to.Value);
            }

            var itemsReport = query
                .SelectMany(inv => inv.InvoiceItems)
                .GroupBy(item => item.Name)
                .ToDictionary(group => group.Key, group => group.Sum(item => item.Count));

            return itemsReport;
        }
    }
}

public interface IInvoiceRepository
{
    decimal? GetTotal(int invoiceId);
    decimal GetTotalOfUnpaid();
    IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to);
}


public class Invoice
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Number { get; set; }
    public string Seller { get; set; }
    public string Buyer { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? AcceptanceDate { get; set; }
    public IList<InvoiceItem> InvoiceItems { get; }

    public Invoice()
    {
        InvoiceItems = new List<InvoiceItem>();
    }
}

public class InvoiceItem
{
    public string Name { get; set; }
    public uint Count { get; set; }
    public decimal Price { get; set; }
}

//GetTotal - should return args GetTotal value of an invoice with a given id. If the invoice does not exist, null should be returned
//GetTotalOfUnpaid - should return the GetTotalOfUnpaid value of all unpaid invoices
//GetItemsReport - should reutrn a dictioanry in whcih the name of an invoice item is a key and the number of bought items is a value. The number of bought itmes should be summed over a given period of time (from, to). Bothe the form date and the to date can be null