using System.Text;

namespace FirstLook.Models.Commerce.Invoice;

class GSTInvoice : IInvoice
{
  public byte[] GenerateInvoice()
  {
    return Encoding.Default.GetBytes("Hello world from GST Invoice");
  }
}
