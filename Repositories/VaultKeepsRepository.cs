using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal VaultKeep Create(VaultKeep VaultKeepData)
    {
      string sql = @"
           INSERT INTO vaultkeeps
           (keepId, vaultId, userId)
           VALUES
           (@KeepId, @VaultId, @UserId);
           SELECT LAST_INSERT_ID()";
      VaultKeepData.Id = _db.ExecuteScalar<int>(sql, VaultKeepData);
      return VaultKeepData;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }

    internal IEnumerable<VaultKeep> Get()
    {
      string sql = "SELECT * FROM vaultkeeps";
      return _db.Query<VaultKeep>(sql);
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
      SELECT 
        k.*,
        vk.id as vaultKeepId
      FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<VaultKeepViewModel>(sql, new { vaultId, userId });
    }

    internal IEnumerable<VaultKeepViewModel> GetByUserId(string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps WHERE keepId = 3";
      return _db.Query<VaultKeepViewModel>(sql);
    }

    //   internal IEnumerable<VaultKeepViewModel> Get(string userId)
    //   {
    //     string sql = @"
    //     "
    //   }
  }
}