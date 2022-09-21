using BudgetLite.Data.Models;
using BudgetLite.Services.Interfaces;
using BudgetLite.Services.Requests;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<User> signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task CreateUser(CreateAccountRequest createAccountRequest)
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
                await this.signInManager.SignInAsync(newUser, isPersistent: false);
            }
            else
            {
                // TODO: Log error someway
                throw new ArgumentException($"Was not able to create a new account.");
            }
        }
    }
}
