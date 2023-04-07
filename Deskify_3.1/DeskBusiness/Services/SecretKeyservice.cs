using DeskData.Repository;
using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskBusiness.Services
{
    public class SecretKeyservice
    {
        ISecretKeyRepository _secretKey;
        public SecretKeyservice(ISecretKeyRepository secretKey)
        {
            _secretKey = secretKey;
        }   

        public void AddSecretKey(SecretKey secretKey)
        {
            _secretKey.AddSecretKey(secretKey);
        }
        public void DeleteSecretKey(int secretId)
        {
            _secretKey?.DeleteSecretKey(secretId);
        }

        public SecretKey GetSecretKeyById(int secretId)
        {
            return _secretKey.GetSecretKeyById(secretId);
        }

        public IEnumerable<SecretKey> GetAllSecretKeys()
        {
            return _secretKey.GetAllSecretKeys();
        }

        public void UpdateSecretKey(SecretKey secretKey)
        {
            _secretKey.UpdateSecretKey(secretKey);
        }

        public SecretKey GetSecretKeyByEmployeeId(int employeeId)
        {
            return _secretKey.GetSecretKeyByEmployeeId(employeeId);
        }

        public SecretKey GetEmployeeIdBySecretKey(string secretKeyType)
        {
            return _secretKey.GetEmployeeIdBySecretKey(secretKeyType);
        }
    }
}
