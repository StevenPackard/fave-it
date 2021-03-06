using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault Get(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    internal Vault Create(Vault VaultData)
    {
      string sql = @"
           INSERT INTO vaults
           (name, description, img, userId)
           VALUES
           (@Name, @Description,@Img, @UserId);
           SELECT LAST_INSERT_ID()";
      VaultData.Id = _db.ExecuteScalar<int>(sql, VaultData);
      return VaultData;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaults WHERE id = @id AND userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }

    internal IEnumerable<Vault> GetByUserId(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }
    internal Vault GetById(int id, string userId)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id AND userId = @userId";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id, userId });
    }
  }
}