using FirstLook.Models.Commerce;
using FirstLook.Models.Shipping.Factories;

Console.Write("Recipient Country: ");
var recipientCountry = Console.ReadLine()?.Trim();

Console.Write("Sender Country: ");
var senderCountry = Console.ReadLine()?.Trim();

Console.Write("Total Order Weight: ");
var totalWeight = Convert.ToInt32(Console.ReadLine()?.Trim());

if (string.IsNullOrWhiteSpace(recipientCountry))
{
  Console.WriteLine("Recipient Country is required.");
  return;
}

if (string.IsNullOrWhiteSpace(senderCountry))
{
  Console.WriteLine("Sender Country is required.");
  return;
}

var order = new Order
{
  Recipient = new Address
  {
    To = "Filip Ekberg",
    Country = recipientCountry
  },

  Sender = new Address
  {
    To = "Someone else",
    Country = senderCountry
  },

  TotalWeight = totalWeight
};

order.LineItems.Add(new("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
order.LineItems.Add(new("CONSULTING", "Building a website", 100m), 1);

var cart = new ShoppingCart(order, new StandardShippingProviderFactory());

var shippingLabel = cart.Finalize();

Console.WriteLine(shippingLabel);
