using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace jwt_project.DAL
{
	public class BuildToken
	{
		public string CreateToken()
		{
			var bytes = Encoding.UTF8.GetBytes("aspnetcoreproject");
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
			SigningCredentials credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
			JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",notBefore: DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(token);
		}
	}
}
