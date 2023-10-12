// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Cryptography;
// using Microsoft.IdentityModel.Tokens;
//
// string jwt = "<jwt_token_code>"; // Укажите тут токен, который нужно верифицировать
//
// using RSA rsa = RSA.Create();
// rsa.ImportFromPem(File.ReadAllText("Secrets/rsa_public_key_for_jwt.pem"));
//
// JwtSecurityTokenHandler tokenHandler = new();
//
// try
// {
//     tokenHandler.ValidateToken(
//         jwt,
//         new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidIssuer = "IssuerName",
//             ValidAudience = "AudienceName",
//             IssuerSigningKey = new RsaSecurityKey(rsa)
//         },
//         out SecurityToken _);
//
//     Console.WriteLine("JWT токен прошел верификацию!");
// }
// catch (Exception ex)
// {
//     Console.WriteLine("JWT токен НЕ прошел верификацию!");
// }