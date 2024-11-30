using FirstLook.Models.Commerce;

namespace FirstLook.Models.Shipping;

class SwedishShippingProvider(
  string apiKey,
  ShippingCostCalculator shippingCostCalculator,
  CustomsHandlingOptions customsHandlingOptions,
  InsuranceOptions insuranceOptions
) : ShippingProvider(shippingCostCalculator, customsHandlingOptions, insuranceOptions)
{
  private readonly string _apiKey = apiKey;

  public override string GenerateShippingLabelFor(Order order)
  {
    var shippingId = GetShippingId();

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

  private string GetShippingId() => Guid.NewGuid().ToString();
}