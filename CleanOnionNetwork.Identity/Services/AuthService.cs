using CleanOnionNetwork.Application.Constants;
using CleanOnionNetwork.Application.Contracts.Identity;
using CleanOnionNetwork.Application.Models.Identity;
using CleanOnionNetwork.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanOnionNetwork.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, 
                           SignInManager<ApplicationUser> signInManager, 
                           IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user ==null)
            {
                throw new Exception($"User not exits {request.Email}");
            }             
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure : false);
            if(!result.Succeeded)
            {
                throw new Exception($"Credentials not correct");
            }
            var token = await GenerateToken(user);
            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName,
            };
            return authResponse;
        }
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.UserName);
            if(existingUser != null)
            {
                throw new Exception($"Username exists in the DB");
            }
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if(existingEmail != null)
            {
                throw new Exception($"Email exists in the DB");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                UserName = request.UserName,
                EmailConfirmed = true
            };            
            var result = await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"Operator");
                var token = await GenerateToken(user);
                return new RegistrationResponse
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    UserName = user.UserName
                };
            }
            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser User)
        {
            var userClaims = await _userManager.GetClaimsAsync(User);
            var roles = await _userManager.GetRolesAsync(User);
            var rolesClaims = new List<Claim>();
            foreach(var role in roles)
            {
                rolesClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, User.UserName),
                new Claim(JwtRegisteredClaimNames.Email, User.Email),
                new Claim(CustomClaimTypes.Uid, User.Id)
            }.Union(userClaims).Union(rolesClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),                 
                    signingCredentials : signingCredentials
                ); 
            return jwtSecurityToken;
        }
    }
}
