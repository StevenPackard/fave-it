using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    // public IEnumerable<VaultKeepViewModel> Get(string userId)
    // {
    //   return _repo.Get(userId);
    // }
    public VaultKeep Get(int id)
    {
      return _repo.GetById(id);
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("This isnt your vaultkeep homie.");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted";
      }
      throw new Exception("Uh Oh something went wrong.");
    }

    internal IEnumerable<VaultKeep> Get()
    {
      return _repo.Get();
    }

    internal IEnumerable<VaultKeepViewModel> GetByUserId(string userId)
    {
      return _repo.GetByUserId(userId);
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }
  }
}