using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace drinkshack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DrinksController : ControllerBase
  {

    public List<Drink> Drinks = new List<Drink>(){
      new Drink("Soda", .50, "d1"),
      new Drink("Juice", 1.00, "d2"),
      new Drink("Water", 1.50, "d3"),
    };

    // GET api/drinks
    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
      // return new string[] { "value1", "value2" };
      return Ok(Drinks);
    }

    // GET api/drinks/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      // return "value";
      try
      {
        return Ok(Drinks[id]);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/drinks
    [HttpPost]
    // public void Post([FromBody] string value)
    public ActionResult<IEnumerable<Drink>> Post([FromBody] Drink newDrink)
    {
      Drinks.Add(newDrink);
      return Ok(Drinks);
    }

    // PUT api/drinks/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
      try
      {
        Drink found = Drinks.Find(drink => drink.Id == id);
        if (found == null) return BadRequest(new { message = "Bad Id" });
        Drinks.Remove(found);
        return Ok(new { message = "Deleted" });
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}