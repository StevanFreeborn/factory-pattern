namespace FirstLook.Models.Commerce;

class Payment
{
  public required decimal Amount { get; set; }
  public required PaymentProvider PaymentProvider { get; set; }
}