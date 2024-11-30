using FirstLook.Models.Commerce;

namespace FirstLook.Models.Shipping;

abstract class ShippingProvider(
  ShippingCostCalculator shippingCostCalculator,
  CustomsHandlingOptions customsHandlingOptions,
  InsuranceOptions insuranceOptions
)
{
  public ShippingCostCalculator ShippingCostCalculator { get; protected set; } = shippingCostCalculator;
  public CustomsHandlingOptions CustomsHandlingOptions { get; protected set; } = customsHandlingOptions;
  public InsuranceOptions InsuranceOptions { get; protected set; } = insuranceOptions;

  public bool RequireSignature { get; set; }

  public abstract string GenerateShippingLabelFor(Order order);
}

class InsuranceOptions
{
  public bool ProviderHasInsurance { get; set; }
  public bool ProviderHasExtendedInsurance { get; set; }
  public bool ProviderRequiresReturnOnDamage { get; set; }
}

class CustomsHandlingOptions
{
  public TaxOptions TaxOptions { get; set; }
}

class ShippingCostCalculator(
  decimal internationalShippingFee,
  decimal extraWeightFee,
  ShippingType shippingType = ShippingType.Standard
)
{
  private readonly decimal _internationalShippingFee = internationalShippingFee;
  private readonly decimal _extraWeightFee = extraWeightFee;

  public ShippingType ShippingType { get; init; } = shippingType;

  public decimal CalculateFor(
    string destinationCountry,
    string originCountry,
    decimal weight
  )
  {
    var total = 10m;

    if (destinationCountry != originCountry)
    {
      total += _internationalShippingFee;
    }

    if (weight > 5)
    {
      total += _extraWeightFee;
    }

    return ShippingType switch
    {
      ShippingType.Express => total + 20,
      ShippingType.NextDay => total + 50,
      _ => total
    };
  }
}

enum TaxOptions
{
  PrePaid,
  DutyFree,
  PayOnArrival
}

enum ShippingType
{
  Standard,
  Express,
  NextDay
}

enum ShippingStatus
{
  WaitingForPayment,
  ReadyForShipment,
  Shipped
}