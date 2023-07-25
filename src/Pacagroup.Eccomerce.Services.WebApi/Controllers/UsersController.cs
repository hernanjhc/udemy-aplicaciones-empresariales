using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Application.Interface;
using Pacagroup.Eccomerce.Services.WebApi.Helpers;
using Pacagroup.Eccomerce.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pacagroup.Eccomerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _usersApplication = usersApplication;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UsersDto authDto)
        {
            var response = _usersApplication.Authenticate(authDto.UserName, authDto.Password);
            if (response.IsSuccess == true)
            {
                if (response.Data != null)
                {
                    //Contruir token
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }
            }
            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDto> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
