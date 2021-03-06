using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("my-keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetKeepsByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      try
      {

        if (HttpContext.User.Identity.IsAuthenticated)
        {
          string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          return Ok(_ks.Get(id, userId));
        }

        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Keep> Edit(int id, [FromBody] Keep editKeep)
    {
      try
      {
        editKeep.Id = id;
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.Edit(editKeep, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Post([FromBody] Keep newKeep)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newKeep.UserId = userId;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

  }
}