using FirstLook.Models.Shipping;
using FirstLook.Models.Shipping.Factories;

namespace FirstLook.Models.Commerce;

class ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
{
  private readonly Order _order = order;
  private readonly ShippingProviderFactory _shippingProviderFactory = shippingProviderFactory;

  public string Finalize()
  {
    var shippingProvider = _shippingProviderFactory.GetShippingProvider(_order.Recipient.Country);

    _order.UpdateShippingStatus(ShippingStatus.ReadyForShipment);

    return shippingProvider.GenerateShippingLabelFor(_order);
  }
}