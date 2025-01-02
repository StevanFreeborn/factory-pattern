using FirstLook.Models.Commerce;

namespace FirstLook.Models.Shipping;

class GlobalExpressShippingProvider(
  ShippingCostCalculator shippingCostCalculator,
  CustomsHandlingOptions customsHandlingOptions,
  InsuranceOptions insuranceOptions
) : ShippingProvider(shippingCostCalculator, customsHandlingOptions, insuranceOptions)
{
  public override string GenerateShippingLabelFor(Order order)
  {
    return "GLOBAL-EXPRESS";
  }
}