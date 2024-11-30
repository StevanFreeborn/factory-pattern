namespace FirstLook.Models.Commerce;

class Item(string id, string name, decimal price)
{
  public string Id { get; } = id;
  public string Name { get; } = name;
  public decimal Price { get; } = price;
}