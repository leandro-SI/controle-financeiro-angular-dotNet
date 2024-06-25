using AutoMapper;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TokenService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public string GenerateToken(Usuario user, string funcao)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration["Jwt:SecretKey"];
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, funcao)
                }),
                //NotBefore = expires,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            //var issuer = _configuration["Jwt:Issuer"];
            //var audience = _configuration["Jwt:Audience"];

            //var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //var tokenOptions = new JwtSecurityToken(
            //    issuer: issuer,
            //    audience: audience,
            //    claims: new[]
            //    {
            //        new Claim("name", user.UserName),
            //        new Claim("role", funcao),
            //        new Claim("id", user.Id)
            //    },
            //    expires: DateTime.UtcNow.AddHours(2),
            //    signingCredentials: signinCredentials
            //);

            //var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            //return token;

        }
    }
}
