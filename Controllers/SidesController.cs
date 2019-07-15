using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace sideshack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SidesController : ControllerBase
  {
    public List<Side> Sides = new List<Side>(){
      new Side("Fries", .50, "s1"),
      new Side("Tots", .50, "s2"),
      new Side("Salad", 1.50, "s3"),
    };
    // GET api/sides
    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      // return new string[] { "value1", "value2" };
      return Ok(Sides);
    }

    // GET api/sides/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      // return "value";
      try
      {
        return Ok(Sides[id]);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/sides
    [HttpPost]
    // public void Post([FromBody] string value)
    public ActionResult<IEnumerable<Side>> Post([FromBody] Side newSide)
    {
      Sides.Add(newSide);
      return Ok(Sides);
    }

    // PUT api/sides/5
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
        Side found = Sides.Find(side => side.Id == id);
        if (found == null) return BadRequest(new { message = "Bad Id" });
        Sides.Remove(found);
        return Ok(new { message = "Deleted" });
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}