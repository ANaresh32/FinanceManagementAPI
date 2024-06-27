using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinanceManagement.API.Models.Response;
using FinanceManagement.CORE.Entities;

namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;

        public LoginController(IEmployeeService employeeService, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ItemResponse> Login([FromBody] LoginRequest request)
        {
            var response = new ItemResponse();

            try
            {
                response.Item = await _employeeService.AuthenticateAsync(request.Email, request.Password);


                if (response.Item == null)
                {
                    response.Error = new Error { Message = "Email or password is incorrect" };
                    response.IsSuccess = false;
                    
                }

                var token = GenerateJwtToken((Employee)response.Item);
                response.IsSuccess = true;
                response.Item = new
                {
                    Employee = response.Item,
                    Token = token
                };

                return response;
            }
            catch (FinanceException ex)
            {
                response.Error = new Error { Message = ex.Message };
                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                response.Error = new Error { Message = $"Internal server error: {ex.Message}" };
                response.IsSuccess = false;
            }

            return response;
        }

        private string GenerateJwtToken(Employee employee)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, employee.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
