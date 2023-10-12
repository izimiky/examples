using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

using RSA rsa = RSA.Create();
rsa.ImportFromPem(File.ReadAllText("Secrets/rsa_private_key_for_jwt.pem"));

SecurityKey securityKey = new RsaSecurityKey(rsa);
SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

SecurityTokenDescriptor descriptor = new()
{
    Issuer = "IssuerName",
    Audience = "AudienceName",
    Expires = DateTime.UtcNow.AddMinutes(5),
    SigningCredentials = signingCredentials,
    Subject = new ClaimsIdentity(new Claim[]
    {
        new(ClaimTypes.NameIdentifier, "exampleUser123")
    })
};

JwtSecurityTokenHandler tokenHandler = new();
SecurityToken token = tokenHandler.CreateToken(descriptor);
string jwt = tokenHandler.WriteToken(token);

Console.WriteLine($"JWT: {jwt}");

try
{
    tokenHandler.ValidateToken(
        jwt,
        new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "IssuerName",
            ValidAudience = "AudienceName",
            IssuerSigningKey = securityKey
        },
        out SecurityToken _);

    Console.WriteLine("JWT токен прошел верификацию!");
}
catch (Exception ex)
{
    Console.WriteLine("JWT токен НЕ прошел верификацию!");
}