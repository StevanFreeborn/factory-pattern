namespace FirstLook.Models.Shipping.Factories;

class StandardShippingProviderFactory : ShippingProviderFactory
{
  protected override ShippingProvider CreateProvider(string country)
  {
    ShippingProvider shippingProvider;

    if (country is "Australia")
    {
      var shippingCostCalculator = new ShippingCostCalculator(
        internationalShippingFee: 250,
        extraWeightFee: 500
      )
      {
        ShippingType = ShippingType.Standard
      };

      var customsHandlingOptions = new CustomsHandlingOptions
      {
        TaxOptions = TaxOptions.PrePaid
      };

      var insuranceOptions = new InsuranceOptions
      {
        ProviderHasInsurance = false,
        ProviderHasExtendedInsurance = false,
        ProviderRequiresReturnOnDamage = false
      };

      shippingProvider = new AustraliaPostShippingProvider(
        "CLIENT_ID",
        "SECRET",
        shippingCostCalculator,
        customsHandlingOptions,
        insuranceOptions
      );
    }
    else if (country is "Sweden")
    {
      var shippingCostCalculator = new ShippingCostCalculator(
        internationalShippingFee: 50,
        extraWeightFee: 100
      )
      {
        ShippingType = ShippingType.Express
      };

      var customsHandlingOptions = new CustomsHandlingOptions
      {
        TaxOptions = TaxOptions.PayOnArrival
      };

      var insuranceOptions = new InsuranceOptions
      {
        ProviderHasInsurance = true,
        ProviderHasExtendedInsurance = false,
        ProviderRequiresReturnOnDamage = false
      };

      shippingProvider = new SwedishShippingProvider(
        "API_KEY",
        shippingCostCalculator,
        customsHandlingOptions,
        insuranceOptions
      );
    }
    else
    {
      throw new NotSupportedException("No shipping provider found for origin country");
    }

    return shippingProvider;
  }
}