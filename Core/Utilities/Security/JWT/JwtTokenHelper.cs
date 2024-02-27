using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT;

public class JwtTokenHelper :ITokenHelper
{
    private IConfiguration _configuration;
    private TokenOptions _tokenOptions;

    public JwtTokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateToken(User user,UserRole? userRole)
    {
        // TODO: Refactor
        DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        Claim[] claims = new[]
        {
            new Claim("Admin",userRole.RoleId.ToString())
        };
        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            expires: expirationTime,
            signingCredentials: signingCredentials,
            notBefore: DateTime.Now,
            claims:claims
            
        );
        
        

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        string token = handler.WriteToken(jwt);

        return new AccessToken()
        {
            Token = token,
            ExpirationTime = expirationTime,
        };
    } 
}