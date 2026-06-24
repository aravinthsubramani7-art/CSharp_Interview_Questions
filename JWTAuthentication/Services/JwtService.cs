namespace JWTAuthentication.Services;

using System.Security.Claims;
using System.Text;
using JWTAuthentication.Models.Api;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

public class JwtService
{
    private readonly IConfiguration _configuration;
    public JwtService(IConfiguration configuration)
    {        
        _configuration = configuration;
    }

    public async Task<LoginResponseModel?> Authenticate(LoginRequestModel request)
    {
        if(string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            return null;
        
        var issuer = _configuration["JwtConfig:Issuer"];
        var audience = _configuration["JwtConfig:Audience"];
        var key = _configuration["JwtConfig:Key"];
        var tokenvalidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins"); 
        var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenvalidityMins);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, request.UserName) //Subject means What information should be stored?
            }),
            Expires = tokenExpiryTimeStamp, //Means When should token die?
            Issuer = issuer, //Means Who created token?
            Audience = audience, //Means Who can use token?
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256), //Means Digitally sign token
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor); //means Token creation, Build JWT
        var accessToken = tokenHandler.WriteToken(securityToken); //means Convert JWT to string

        return new LoginResponseModel
        {
            AccessToken = accessToken,
            UserName = request.UserName,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
        };
    }
}