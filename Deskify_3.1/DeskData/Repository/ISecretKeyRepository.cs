using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskData.Repository
{
    public interface ISecretKeyRepository
    {
        void AddSecretKey(SecretKey secretKey);
        void DeleteSecretKey(int secretId);
        void UpdateSecretKey(SecretKey secretKey);
        SecretKey GetSecretKeyById(int secretId);
        IEnumerable<SecretKey> GetAllSecretKeys();

        SecretKey GetSecretKeyByEmployeeId(int employeeId);
        SecretKey GetEmployeeIdBySecretKey(string secretKeyType);
    }
}
