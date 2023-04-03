using ITI_Jumiaaa.API.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.ProjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ITI_Jumiaaa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //Register New Account
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);
            user.Username = request.UserName;
            user.PasswordHash = passwordhash;
            user.PasswordSalt = passwordsalt;
            return Ok(user);
        }
        // Login Account
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            // if username not matching 
            if (user.Username != request.UserName)
            {
                return BadRequest("User Not Found Please Register New Account");
            }
            // if password wrong
            if(!VerifyPasswordHash(request.Password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest("Wrong Password Pls reWrite True.");
            }

            ///  Create Token of USer to Check it exist in Dbs or not
            string Token = CreateToken(user);
            return Ok(Token);
        }

        // Create Method Token from User 
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Username)
            };
            // To Get the Key from AppSetting on Dbs (Token Stored)
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(configuration.GetSection("AppSettings:Token").Value));

            // Check Credntial
            var cred =new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            // then get token and return it 
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        // Create Password Hash with JWT Json Web Token
        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            // create password hash with alogorithm of Cryptography
            using (var hmac = new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // Verify Password HAsh
        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt)
        {
            // create password hash with alogorithm of Cryptography
            using (var hmac = new HMACSHA512(passwordsalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                // if login successfully
                return computedHash.SequenceEqual(passwordhash);
            }

        }
    }
}
