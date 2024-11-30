using FirstLook.Models.Commerce;

namespace FirstLook.Models.Shipping;

class AustraliaPostShippingProvider(
  string clientId,
  string secret,
  ShippingCostCalculator shippingCostCalculator,
  CustomsHandlingOptions customsHandlingOptions,
  InsuranceOptions insuranceOptions
) : ShippingProvider(shippingCostCalculator, customsHandlingOptions, insuranceOptions)
{
  private readonly string _clientId = clientId;
  private readonly string _secret = secret;

  public override string GenerateShippingLabelFor(Order order)
  {
    var shippingId = GetShippingId();

    if (order.Recipient.Country != order.Sender.Country)
    {
      throw new NotSupportedException("International shipping not supported");
    }

    var shippingCost = ShippingCostCalculator.CalculateFor(
      order.Recipient.Country,
      order.Sender.Country,
      order.TotalWeight
    );

    return $"Shipping Id: {shippingId} {Environment.NewLine}" +
      $"To: {order.Recipient.To} {Environment.NewLine}" +
      $"Order total: {order.Total} {Environment.NewLine}" +
      $"Tax: {CustomsHandlingOptions.TaxOptions} {Environment.NewLine}" +
      $"Shipping Cost: {shippingCost}";
  }

  private string GetShippingId() => $"AUS-{Guid.NewGuid()}";
}