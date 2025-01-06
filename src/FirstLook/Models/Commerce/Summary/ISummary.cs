namespace FirstLook.Models.Commerce.Summary;

interface ISummary
{
  string CreateOrderSummary(Order order);
  void Send();
}

class EmailSummary : ISummary
{
  public string CreateOrderSummary(Order order)
  {
    return "This this is an email order summary";
  }

  public void Send()
  {
    Console.WriteLine("Email summary sent");
  }
}

class CsvSummary : ISummary
{
  public string CreateOrderSummary(Order order)
  {
    return "This this is a CSV order summary";
  }

  public void Send()
  {
    Console.WriteLine("CSV summary sent");
  }
}