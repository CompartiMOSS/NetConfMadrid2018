using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IS4.Auth.AspNetIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;

namespace IS4.Auth
{
    public static class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {  
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<IConfigurationDbContext>())
                {
                    EnsureSeedDataIdentityServer(context);
                }

                using (var context = scope.ServiceProvider.GetService<AspNetIdentityDbContext>())
                { 
                    EnsureSeedDataAspnetIdentity(context, scope.ServiceProvider.GetRequiredService<UserManager<User>>());
                }
            }
        }

        private static void EnsureSeedDataIdentityServer(IConfigurationDbContext context)
        {
            Console.WriteLine("Seeding database...");

            if (!context.Clients.Any())
            {
                Console.WriteLine("Clients being populated");
                foreach (var client in Config.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Clients already populated");
            }

            if (!context.IdentityResources.Any())
            {
                Console.WriteLine("IdentityResources being populated");
                foreach (var resource in Config.GetIdentityResources())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!context.ApiResources.Any())
            {
                Console.WriteLine("ApiResources being populated");
                foreach (var resource in Config.GetApiResources())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static void EnsureSeedDataAspnetIdentity(AspNetIdentityDbContext context, UserManager<User> userMgr)
        {
            context.Database.Migrate();

            var adrian = userMgr.FindByNameAsync("adrian").Result;
            if (adrian == null)
            {
                adrian = new User
                {
                    UserName = "adrian",
                    Status = 1
                };
                var result = userMgr.CreateAsync(adrian, "realmadridcampeondeeuropaunavezmas").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(adrian, new Claim[]{
                                                            new Claim(JwtClaimTypes.Name, "Adrián Díaz"),
                                                            new Claim(JwtClaimTypes.GivenName, "Adrián"),
                                                            new Claim(JwtClaimTypes.FamilyName, "Díaz"),
                                                            new Claim(JwtClaimTypes.Email, "adiaz@encamina.com"),
                                                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                                                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Console.WriteLine("adrian created");
            }
            else
            {
                Console.WriteLine("adrian already exists");
            }

            var parrita = userMgr.FindByNameAsync("parrita").Result;
            if (parrita == null)
            {
                parrita = new User
                {
                    UserName = "parrita",
                    Status = 1
                };
                var result = userMgr.CreateAsync(parrita, "thesame").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(parrita, new Claim[]{
                                                            new Claim(JwtClaimTypes.Name, "Sergio Parra"),
                                                            new Claim(JwtClaimTypes.GivenName, "Sergio"),
                                                            new Claim(JwtClaimTypes.FamilyName, "Parra"),
                                                            new Claim(JwtClaimTypes.Email, "sparra@encamina.com"),
                                                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                                                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Console.WriteLine("parrita created");
            }
            else
            {
                Console.WriteLine("parrita already exists");
            }
        }
    } 
}