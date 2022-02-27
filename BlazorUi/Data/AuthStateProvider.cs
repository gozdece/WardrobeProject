using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorUi.Data
{
  
        public class AuthStateProvider : AuthenticationStateProvider
        {
            private readonly ProtectedLocalStorage localStorageService;
            private readonly HttpClient client;
            private readonly AuthenticationState anonymous;

            public AuthStateProvider(ProtectedLocalStorage LocalStorageService, HttpClient Client)
            {
                localStorageService = LocalStorageService;
                client = Client;
                anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            public async override Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                var apiToken = await localStorageService.GetAsync<string>("token");

            if (String.IsNullOrEmpty(apiToken.Value))
                    return anonymous;


                var email = await localStorageService.GetAsync<string>("email");

                var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email.Value) }, "jwtAuthType"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken.Value);

                return new AuthenticationState(cp);
            }

        internal void NotifyUserAuthentication(object email)
        {
            throw new NotImplementedException();
        }

        public void NotifyUserLogin(String email)
            {
                var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
                var authState = Task.FromResult(new AuthenticationState(cp));

                NotifyAuthenticationStateChanged(authState);
            }

            public void NotifyUserLogout()
            {
                var authState = Task.FromResult(anonymous);
                NotifyAuthenticationStateChanged(authState);
            }
        }
    }