using DeskData.Data;
using DeskEntity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskData.Repository
{
    public class SecretKeyRepository : ISecretKeyRepository
    {
        DeskDbContext _db;
        public SecretKeyRepository( DeskDbContext db )
        {
            _db = db;
        }
        public void AddSecretKey(SecretKey secretKey)
        {
            _db.Add( secretKey );
            _db.SaveChanges();
        }

        public void DeleteSecretKey(int secretId)
        {
            var secretkey = _db.secretKeys.Find(secretId);
            _db.secretKeys.Remove(secretkey);
            _db.SaveChanges();
        }

        public IEnumerable<SecretKey> GetAllSecretKeys()
        {
            return _db.secretKeys.ToList();
        }

        public SecretKey GetSecretKeyById(int secretId)
        {
            return _db.secretKeys.Find(secretId);
        }

        public void UpdateSecretKey(SecretKey secretKey)
        {
            _db.Entry(secretKey).State=EntityState.Modified;
            _db.SaveChanges();
        }

        

        public SecretKey GetSecretKeyByEmployeeId(int employeeId)
        {
            List<SecretKey> secretKeys = _db.secretKeys.Include(obj => obj.Employee).ToList();
            List<SecretKey> secretKeyList = new List<SecretKey>();
            foreach (var item in secretKeys)
            {
                if (employeeId == item.EmployeeID)
                {
                    return item;
                }
            }
            return null;
        }

        public SecretKey GetEmployeeIdBySecretKey(string secretKeyType)
        {
            List<SecretKey> secretKeys = _db.secretKeys.Include(obj => obj.Employee).ToList();
            List<SecretKey> secretKeyList = new List<SecretKey>();
            foreach (var item in secretKeys)
            {
                if (secretKeyType == item.SecretKeyType)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
