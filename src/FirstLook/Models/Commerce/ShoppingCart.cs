using FirstLook.Models.Shipping;
using FirstLook.Models.Shipping.Factories;

namespace FirstLook.Models.Commerce;

class ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
{
  private readonly Order _order = order;
  private readonly IPurchaseProviderFactory _purchaseProviderFactory = purchaseProviderFactory;

  public string Finalize()
  {
    var shippingProvider = _purchaseProviderFactory.CreateShippingProvider(_order);
    var invoice = _purchaseProviderFactory.CreateInvoice(_order);
    var summary = _purchaseProviderFactory.CreateSummary(_order);

    summary.Send();

    _order.UpdateShippingStatus(ShippingStatus.ReadyForShipment);

    return shippingProvider.GenerateShippingLabelFor(_order);
  }
}