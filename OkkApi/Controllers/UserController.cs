using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OkkApi.Models;
using OkkApi.Models.Response;
using OkkApi.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OkkApi.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices userServices;
        IConfiguration _configuration;

        public UserController(IUserServices userServices,IConfiguration _configuration)
        {
            this.userServices = userServices;
            this._configuration = _configuration;
        }

        /// <summary>
        /// id-> User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = userServices.GetUserDetailsById(id);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// TCKNO Bilgisine göre kullanıcıyı getiren endpoint
        /// </summary>
        /// <param name="TCKNO"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        
        public IActionResult GetUserByTCKNO(long TCKNO)
        {
            try
            {
                var user = userServices.GetUserDetailsByTCKNO(TCKNO);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        ///// <summary>
        ///// plate based user query is match or not match
        ///// </summary>
        ///// <param name="plate"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("[action]/plate")]
        //public IActionResult GetPlateFromUser(string plate)
        //{
        //    try
        //    {
        //        var user = userServices.PlateQuery(plate);
        //        if (user == null) return NotFound();
        //        return Ok(user);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        /// <summary>
        /// user add or update
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveUser(User userModel)
        {
            try
            {
                var user = userServices.SaveUser(userModel);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// delete user hard delete (not softdelete )
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var model = userServices.DeleteUser(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Login")]
        [AllowAnonymous()]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            var response = new Dictionary<string, string>();
            if (!(request.UserName == "admin" && request.Password == "123456"))
            {
                response.Add("Error", "Invalid username or password");
                return BadRequest(response);
            }

         
            var token = GenerateJwtToken(request.UserName);
            return Ok(new LoginResponseModel()
            {
                Access_Token = token,
                UserName = request.UserName
            });
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, username)
        };

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
