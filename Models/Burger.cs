using System.ComponentModel.DataAnnotations;

namespace burgershack.Controllers
{
  public class Burger
  {
    public string Id { get; set; }
    // [Required]
    public string Type { get; set; }

    // [Required]
    public double Price { get; set; }

    public Burger(string type, double price, string id)
    {
      Type = type;
      Price = price;
      Id = id;
    }
  }
}