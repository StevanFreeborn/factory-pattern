namespace FirstLook.Models.Shipping.Factories;

class GlobalExpressShippingProviderFactory : ShippingProviderFactory
{
  protected override ShippingProvider CreateProvider(string country) => new GlobalExpressShippingProvider(
    new(internationalShippingFee: 100, extraWeightFee: 200) { ShippingType = ShippingType.Express },
    new() { TaxOptions = TaxOptions.PayOnArrival },
    new() { ProviderHasInsurance = true, ProviderHasExtendedInsurance = true, ProviderRequiresReturnOnDamage = true }
  );
}