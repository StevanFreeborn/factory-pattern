using FirstLook.Models.Shipping;

namespace FirstLook.Models.Commerce;

class ShoppingCart(Order order)
{
  private readonly Order _order = order;

  public string Finalize()
  {
    var shippingProvider = ShippingProviderFactory.CreateProvider(_order.Recipient.Country);

    _order.UpdateShippingStatus(ShippingStatus.ReadyForShipment);

    return shippingProvider.GenerateShippingLabelFor(_order);
  }
}