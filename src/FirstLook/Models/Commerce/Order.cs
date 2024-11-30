using FirstLook.Models.Shipping;

namespace FirstLook.Models.Commerce;

class Order
{
  public Dictionary<Item, int> LineItems { get; } = [];
  public IList<Payment> SelectedPayments { get; } = [];
  public IList<Payment> FinalizedPayments { get; } = [];
  public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) - FinalizedPayments.Sum(payment => payment.Amount);
  public decimal Total => LineItems.Sum(item => item.Key.Price * item.Value);
  public ShippingStatus ShippingStatus { get; private set; } = ShippingStatus.WaitingForPayment;
  public Address Recipient { get; init; } = new();
  public Address Sender { get; init; } = new();
  public decimal TotalWeight { get; init; }

  public void UpdateShippingStatus(ShippingStatus status)
  {
    ShippingStatus = status;
  }
}

class Address
{
  public string To { get; init; } = "N/A";
  public string AddressLine1 { get; init; } = "N/A";
  public string AddressLine2 { get; init; } = "N/A";
  public string PostalCode { get; init; } = "N/A";
  public string City { get; init; } = "N/A";
  public string Country { get; init; } = "N/A";
}