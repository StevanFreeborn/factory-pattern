using System.Text;

namespace FirstLook.Models.Commerce.Invoice;

class VATInvoice : IInvoice
{
  public byte[] GenerateInvoice()
  {
    return Encoding.Default.GetBytes("Hello world from VAT Invoice");
  }
}
