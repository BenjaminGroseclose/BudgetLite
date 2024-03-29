﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace BudgetLite.Web.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILogger<CustomAuthenticationStateProvider> logger;
        private readonly ProtectedSessionStorage sessionStorage;

        private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private const string USER_SESSION = "UserSession";

        public CustomAuthenticationStateProvider(ILogger<CustomAuthenticationStateProvider> logger, ProtectedSessionStorage sessionStorage)
        {
            this.logger = logger;
            this.sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await this.sessionStorage.GetAsync<UserSession>(USER_SESSION);
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(anonymous));
                }

                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.GivenName, userSession.GivenName),
                    new Claim(ClaimTypes.NameIdentifier, userSession.UserID.ToString()),
                    new Claim(BudgetLiteClaim.Income, userSession.MonthlyIncome.ToString())
                }, "CustomAuthentication");

                var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                return await Task.FromResult(new AuthenticationState(claimsPrinciple));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occured during authentication");
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                await this.sessionStorage.SetAsync(USER_SESSION, userSession);

                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.GivenName, userSession.GivenName),
                    new Claim(ClaimTypes.NameIdentifier, userSession.UserID.ToString()),
                    new Claim(BudgetLiteClaim.Income, userSession.MonthlyIncome.ToString())
                }, "CustomAuthentication");

                claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            }
            else
            {
                await this.sessionStorage.DeleteAsync(USER_SESSION);
                claimsPrincipal = anonymous;
            }

            if (claimsPrincipal != null)
            {
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            }
            else
            {
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
            }
        }
    }
}
