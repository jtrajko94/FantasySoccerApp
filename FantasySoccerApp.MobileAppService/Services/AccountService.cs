using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FantasySoccerApp.MobileAppService.Models;
using FantasySoccerApp.MobileAppService.Models.Accounts;
using FantasySoccerApp.MobileAppService.Services.Interfaces;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FantasySoccerApp.MobileAppService.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAzureKeyVaultService _azureKeyVaultService;
        public AccountService(UserManager<AspNetUsers> userManager,
            IConfiguration configuration,
            IAzureKeyVaultService azureKeyVaultService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _azureKeyVaultService = azureKeyVaultService;
        }

        public async Task<ValidationResponse> IsRegistrationValidAsync(UserModel register)
        {
            var issues = new Dictionary<string,string>();

            if(!Validation.Item(ValidationTypes.Email, register.Email))
            {
                issues.Add("Email", "Enter a valid email address");
            }
            else if(await _userManager.FindByEmailAsync(register.Email) != null)
            {
                issues.Add("Email","Another user is using this email address");
            }

            if (!Validation.Item(ValidationTypes.Password, register.Password))
            {
                issues.Add("Password","Password must contain 8 characters with at least one lowercase, uppercase, and special character");
            }
            else if (register.Password != register.ReEnterPassword)
            {
                issues.Add("ReEnterPassword", "Passwords Don't Match");
            }

            if(!Validation.Item(ValidationTypes.FirstAndLastName, register.Name))
            {
                issues.Add("Name", "Full name is required");
            }

            //TODO: Update validation for this for bad language and length
            if (!Validation.Item(ValidationTypes.AnyValue, register.Username))
            {
                issues.Add("Username", "Username is required");
            }

            return new ValidationResponse
            {
                IsValid = !issues.Any(),
                Issues = issues
            };
        }

        public async Task<ValidationResponse> IsLoginValidAsync(UserModel login)
        {
            var issues = new Dictionary<string, string>();

            if (!Validation.Item(ValidationTypes.Email, login.Email))
            {
                issues.Add("Email", "Enter a valid email address");
            }

            if (!Validation.Item(ValidationTypes.AnyValue, login.Password))
            {
                issues.Add("Password", "Password is required");
            }

            if (!issues.Any())
            {
                var user = GetUserByEmail(login.Email);
                if(user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password) || await _userManager.FindByEmailAsync(login.Email) == null)
                {
                    issues.Add("Email", "Email and/or Password are incorrect");
                }
            }

            return new ValidationResponse
            {
                IsValid = !issues.Any(),
                Issues = issues
            };
        }

        public TokenModel CreateBearerToken(DateTime expirationDate)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: expirationDate, signingCredentials: signIn);

            return new TokenModel
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = expirationDate,
                token_type = "Bearer"
            };
        }

        public UserModel GetUser(string id)
        {
            using (var con = new SqlConnection(_azureKeyVaultService.GetKeys()["SQLConnection"]))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "GetUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    var u = new UserModel
                    {
                        Id = result["Id"]?.ToString().ToNullIfWhiteSpace(),
                        Email = result["Email"]?.ToString().ToNullIfWhiteSpace(),
                        Username = result["Username"]?.ToString().ToNullIfWhiteSpace(),
                        Name = result["Name"]?.ToString().ToNullIfWhiteSpace(),
                        Password = result["Password"]?.ToString().ToNullIfWhiteSpace()
                    };
                    return u;
                }
                return null;
            }
        }

        public UserModel GetUserByCredentials(string email, string password)
        {
            using (var con = new SqlConnection(_azureKeyVaultService.GetKeys()["SQLConnection"]))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "GetUserByCredentials";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password.ToPasswordHash());
                con.Open();
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    var u = new UserModel
                    {
                        Id = result["Id"]?.ToString().ToNullIfWhiteSpace(),
                        Email = result["Email"]?.ToString().ToNullIfWhiteSpace(),
                        Username = result["Username"]?.ToString().ToNullIfWhiteSpace(),
                        Name = result["Name"]?.ToString().ToNullIfWhiteSpace(),
                        Password = result["Password"]?.ToString().ToNullIfWhiteSpace()
                    };
                    return u;
                }
                return null;
            }
        }

        public UserModel GetUserByEmail(string email)
        {
            using (var con = new SqlConnection(_azureKeyVaultService.GetKeys()["SQLConnection"]))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "GetUserByEmail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                con.Open();
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    var u = new UserModel
                    {
                        Id = result["Id"]?.ToString().ToNullIfWhiteSpace(),
                        Email = result["Email"]?.ToString().ToNullIfWhiteSpace(),
                        Username = result["Username"]?.ToString().ToNullIfWhiteSpace(),
                        Name = result["Name"]?.ToString().ToNullIfWhiteSpace(),
                        Password = result["Password"]?.ToString().ToNullIfWhiteSpace()
                    };
                    return u;
                }
                return null;
            }
        }

        public string InsertUser(UserModel user)
        {
            using (var con = new SqlConnection(_azureKeyVaultService.GetKeys()["SQLConnection"]))
            {
                var id = Guid.NewGuid().ToString();

                var cmd = con.CreateCommand();
                cmd.CommandText = "InsertUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password.ToPasswordHash());
                con.Open();
                cmd.ExecuteScalar();

                return id.ToString();
            }
        }

        public string Update(UserModel u)
        {
            using (var con = new SqlConnection(_azureKeyVaultService.GetKeys()["SQLConnection"]))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "UpdateUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", u.Id);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Username", u.Username);
                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Password", u.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                return u.Id;
            }
        }
    }
}
