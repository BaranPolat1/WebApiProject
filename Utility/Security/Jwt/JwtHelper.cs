using Entity.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Utility.Security.Encyription;

namespace Utility.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration  { get; }
        private TokenOptions _tokenOptions;
       private DateTime _accesTokenExpration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accesTokenExpration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
       
        public AccesToken CreateToken(AppUser user)
        {
            var securitykey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingredential = SigninCredentialsHelper.CreateSigninCredential(securitykey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,user, signingredential);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccesToken
            {
                Token = token,
                Expiration = _accesTokenExpration
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,AppUser appUser, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accesTokenExpration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

                ) ;
            return jwt;
        }
    }
}
