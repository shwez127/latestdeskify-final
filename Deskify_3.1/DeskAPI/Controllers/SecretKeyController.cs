using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretKeyController : ControllerBase
    {
        private SecretKeyservice _secretService;
        public SecretKeyController(SecretKeyservice secretService)
        {
            _secretService = secretService;
        }
        [HttpGet("GetAllSecretKeys")]
        public IEnumerable<SecretKey> GetAllSecretKeys()
        {
            return _secretService.GetAllSecretKeys();
        }

        [HttpGet("GetSecretKeyById")]
        public SecretKey GetSecretKeyById(int secretId)
        {
            return _secretService.GetSecretKeyById(secretId);
        }

        [HttpPost("AddSecretKey")]
        public IActionResult AddSecretKey([FromBody] SecretKey secretKey)
        {
            try
            {
                _secretService.AddSecretKey(secretKey);
                return Ok("Secret Key Created successfully");
            }
            catch
            {
                return BadRequest(400);
            }

        }

        [HttpDelete("DeleteSecretKey")]
        public IActionResult DeleteSecretKey(int SecretId)
        {
            try
            {
                _secretService.DeleteSecretKey(SecretId);
                return Ok("Secrey Key Deleted sucessfully!!!");
            }

            catch
            {
                return BadRequest(400);
            }
        }

        [HttpPut("UpdateSecretKey")]
        public IActionResult UpdateSecretKey([FromBody] SecretKey secretKey)
        {
            try
            {
                _secretService.UpdateSecretKey(secretKey);
                return Ok("Secret key Updated successfully");
            }
            catch
            {
                return BadRequest(400);
            }


        }

        [HttpGet("GetSecretKeyByEmployeeId")]
        public SecretKey GetSecretKeyByEmployeeId(int employeeId)
        {
            return _secretService.GetSecretKeyByEmployeeId(employeeId);
        }

        [HttpGet("GetEmployeeIdBySecretKey")]
        public SecretKey GetEmployeeIdBySecretKey(string secretKeyType)
        {
            return _secretService.GetEmployeeIdBySecretKey(secretKeyType);
        }

    }
}
