using BudgetLite.Data.Models;
using BudgetLite.Services.Interfaces;
using BudgetLite.Services.Requests;
using BudgetLite.Services.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLite.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly ILogger<UserService> logger;

        public UserService(ILogger<UserService> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.logger = logger;
            this.userManager = userManager;
        }

        public async Task<CreateAccountResponse> CreateUser(CreateAccountRequest createAccountRequest)
        {
            if (!createAccountRequest.IsValid())
            {
                throw new ArgumentException("Create Account Request as not valid");
            }

            User newUser = new User(
                firstName: createAccountRequest.FirstName,
                lastName: createAccountRequest.LastName,
                email: createAccountRequest.Email,
                username: createAccountRequest.Username
            );

            var result = await this.userManager.CreateAsync(newUser, createAccountRequest.Password);

            if (result.Succeeded)
            {
                this.logger.LogInformation("Successfully created user: {username}", newUser.UserName);
                return new CreateAccountResponse(true, newUser, string.Empty);
            }
            else
            {
                this.logger.LogError(result.Errors.ElementAt(0).Description);
                return new CreateAccountResponse(false, null, result.Errors.ElementAt(0).Description);
            }
        }
    }
}
