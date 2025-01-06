using FirstLook.Models.Commerce;
using FirstLook.Models.Commerce.Invoice;
using FirstLook.Models.Commerce.Summary;
using FirstLook.Models.Shipping;
using FirstLook.Models.Shipping.Factories;

namespace FirstLook.Models;

interface IPurchaseProviderFactory
{
  ShippingProvider CreateShippingProvider(Order order);
  ISummary CreateSummary(Order order);
  IInvoice CreateInvoice(Order order);
}

class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
{
  public ShippingProvider CreateShippingProvider(Order order)
  {
    return new StandardShippingProviderFactory().GetShippingProvider(order.Sender.Country);
  }

  public ISummary CreateSummary(Order order)
  {
    return new CsvSummary();
  }

  public IInvoice CreateInvoice(Order order)
  {
    return new GSTInvoice();
  }
}

class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
{
  public IInvoice CreateInvoice(Order order)
  {
    return order.Recipient.Country != order.Sender.Country
      ? new NoVATInvoice()
      : new VATInvoice();
  }

  public ShippingProvider CreateShippingProvider(Order order)
  {
    return order.Recipient.Country != order.Sender.Country
      ? new GlobalExpressShippingProviderFactory().GetShippingProvider(order.Recipient.Country)
      : new StandardShippingProviderFactory().GetShippingProvider(order.Recipient.Country);
  }

  public ISummary CreateSummary(Order order)
  {
    return new EmailSummary();
  }
}
