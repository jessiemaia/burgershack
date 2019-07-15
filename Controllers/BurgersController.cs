using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {
    public List<Burger> Burgers = new List<Burger>(){
      new Burger("Bacon", 1.25, "b1"),
      new Burger("Cheese", 1.00, "b2"),
      new Burger("Double-Cheese", 1.50, "b3"),
    };
    // GET api/burgers
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      // return new string[] { "value1", "value2" };
      return Ok(Burgers);
    }
    // GET api/burgers/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      // return "value";
      try
      {
        return Ok(Burgers[id]);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    // POST api/burgers
    [HttpPost]
    // public void Post([FromBody] string value)
    public ActionResult<IEnumerable<Burger>> Post([FromBody] Burger newBurger)
    {
      Burgers.Add(newBurger);
      return Ok(Burgers);
    }
    // PUT api/burgers/5
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
        Burger found = Burgers.Find(burger => burger.Id == id);
        if (found == null) return BadRequest(new { message = "Bad Id" });
        Burgers.Remove(found);
        return Ok(new { message = "Deleted" });
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
