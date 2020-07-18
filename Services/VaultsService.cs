using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Http;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public Vault Get(int id)
    {

      return _repo.Get(id);
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal string Delete(int id, string userId)
    {
      Vault found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("This isnt your vault homie.");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted";
      }
      throw new Exception("Uh Oh something went wrong.");
    }

    internal IEnumerable<Vault> GetByUserId(string userId)
    {
      return _repo.GetByUserId(userId);
    }

    internal IEnumerable<Vault> GetById(int id, string userId)
    {
      var found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("That aint yours chief");
      }
      return _repo.GetById(id, userId);
    }
  }
}