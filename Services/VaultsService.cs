using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

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
      return _repo.GetById(id);
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

    internal IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get(userId);
    }
  }
}