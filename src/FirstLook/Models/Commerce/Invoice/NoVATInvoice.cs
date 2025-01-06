using System.Text;

namespace FirstLook.Models.Commerce.Invoice;

class NoVATInvoice : IInvoice
{
  public NoVATInvoice()
  {
  }

  public byte[] GenerateInvoice()
  {
    return Encoding.Default.GetBytes("Hello world from No VAT Invoice");
  }
}