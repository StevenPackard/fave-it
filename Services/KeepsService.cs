using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Get(int id)
    {
      return _repo.GetById(id);
    }

    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal string Delete(int id, string userId)
    {
      Keep found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("This isnt your keep homie.");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted";
      }
      throw new Exception("Uh Oh something went wrong.");
    }

    internal Keep Edit(Keep editKeep, string userId)
    {
      Keep found = Get(editKeep.Id);
      if (found.Views < editKeep.Views)
      {
        if (_repo.IncreaseViews(editKeep))
        {
          found.Views = editKeep.Views;
          return found;
        }
        throw new Exception("You cant do that edit.");
      }
      if (found.Keeps < editKeep.Keeps)
      {
        if (_repo.IncreaseKeeps(editKeep))
        {
          found.Keeps = editKeep.Keeps;
          return found;
        }
        throw new Exception("You cant do that edit.");

      }
      if (found.UserId == userId && _repo.Edit(editKeep, userId))
      {
        return editKeep;
      }
      throw new Exception("You cant do that edit.");

    }
  }
}