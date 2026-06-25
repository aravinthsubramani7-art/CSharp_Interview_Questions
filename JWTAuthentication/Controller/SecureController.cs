using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthentication.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase  //this is the controller especially to manually validate the JWT 
    {
        public readonly IConfiguration _configuration;
        public SecureController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("manual-validate")]
        public IActionResult ManualValidate()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            // 1. Check Header
            if(string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized("Missing Authorization Header");
            }

            //2. Extract token
            var token = authHeader.Substring("Bearer ".Length).Trim();

            //3.Secret Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]!));

            //4. Validation Rules
            var tokenValidationParameters = 
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true, //validate expiration of the token
                ValidateIssuerSigningKey = true,

                ValidIssuer = _configuration["JwtConfig:Issuer"],
                ValidAudience = _configuration["JwtConfig:Audience"],
                IssuerSigningKey = key
            };

            try
            {
                //5.Validate token
                var handler = new JwtSecurityTokenHandler();

                var principle = handler.ValidateToken(token, tokenValidationParameters, out SecurityToken validateToken); //this is the in-build method to validate the token

                //6.Read Claims
                var username = principle.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

                return Ok(new
                {
                    Message = "Token Valid",
                    UserName = username
                });
            }

            catch(SecurityTokenExpiredException ex)
            {
                return Unauthorized(new
                {
                    Error = "TOKEN EXPIRED",
                    Message = ex.Message
                });
            }

            catch(SecurityTokenInvalidSignatureException ex)
            {
                return Unauthorized(new
                {
                    Error = "TOKEN TAMPERED",
                    Message = ex.Message
                });
            }

            catch (SecurityTokenException ex)
            {
                return Unauthorized(new
                {
                    Error = "INVALID TOKEN",
                    Message = ex.Message
                });
            }
            
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = "GENERAL ERROR",
                    Message = ex.Message
                });
            }
        }
    }
}