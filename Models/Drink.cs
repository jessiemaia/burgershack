using System.ComponentModel.DataAnnotations;

namespace drinkshack.Controllers
{
  public class Drink
  {
    public string Id { get; set; }
    // [Required]
    public string Type { get; set; }

    // [Required]
    public double Price { get; set; }

    public Drink(string type, double price, string id)
    {
      Type = type;
      Price = price;
      Id = id;
    }
  }
}