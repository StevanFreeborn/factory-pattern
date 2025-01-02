namespace FirstLook.Models.Shipping.Factories;

abstract class ShippingProviderFactory
{
  protected abstract ShippingProvider CreateProvider(string country);

  public ShippingProvider GetShippingProvider(string country)
  {
    var provider = CreateProvider(country);

    if (country is "Sweden" && provider.InsuranceOptions.ProviderHasInsurance)
    {
      provider.RequireSignature = false;
    }

    return provider;
  }
}