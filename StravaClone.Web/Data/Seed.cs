using Microsoft.AspNetCore.Identity;
using StravaClone.Web.Data.Enum;
using StravaClone.Web.Models;

namespace StravaClone.Web.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Marathon Mavericks",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A club for those who love the thrill of long-distance running. Whether you're training for your first marathon or you're a seasoned runner, this group provides motivation and community support.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Club()
                        {
                            Title = "Speed Demons",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This club is all about running fast and pushing your limits. From short sprints to long intervals, Speed Demons focuses on improving personal bests and keeping a competitive edge.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "456 Oak Ave",
                                City = "Atlanta",
                                State = "GA"
                            }
                        },
                        new Club()
                        {
                            Title = "Trail Blazers",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "For those who love running in nature, Trail Blazers explores local trails and promotes outdoor fitness.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "789 Pine Blvd",
                                City = "Miami",
                                State = "FL"
                            }
                        },
                        new Club()
                        {
                            Title = "Run for Fun",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A casual running club focused on enjoying the experience and meeting new friends.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "101 Maple Rd",
                                City = "Chicago",
                                State = "IL"
                            }
                        },
                        new Club()
                        {
                            Title = "Sprint Squad",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A high-energy group dedicated to improving speed and technique through various workouts.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "202 Cedar St",
                                City = "Seattle",
                                State = "WA"
                            }
                        },
                        new Club()
                        {
                            Title = "Endurance Experts",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "For runners focused on building stamina for long races and events.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "303 Elm St",
                                City = "Denver",
                                State = "CO"
                            }
                        },
                        new Club()
                        {
                            Title = "Fast Trackers",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A club for competitive runners looking to improve their times and techniques.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "404 Birch St",
                                City = "Boston",
                                State = "MA"
                            }
                        },
                        new Club()
                        {
                            Title = "Fun Run Collective",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "An inclusive running group for all skill levels that emphasizes enjoyment and community.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "505 Spruce St",
                                City = "Portland",
                                State = "OR"
                            }
                        },
                        new Club()
                        {
                            Title = "Urban Runners",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Explore the city on foot with a community of urban runners.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "606 Willow St",
                                City = "San Francisco",
                                State = "CA"
                            }
                        },
                        new Club()
                        {
                            Title = "Night Runners",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A unique club that meets in the evening to run under the stars.",
                            ClubCategory = ClubCategory.City,
                            Address = new Address()
                            {
                                Street = "707 Poplar St",
                                City = "New York",
                                State = "NY"
                            }
                        }

                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Races.Any())
                {
                    context.Races.AddRange(new List<Race>()
                    {
                        new Race()
                        {
                            Title = "Charlotte Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "An annual marathon attracting runners from all over the country.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Race()
                        {
                            Title = "Atlanta Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A scenic marathon through the heart of Atlanta.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "456 Peach St",
                                City = "Atlanta",
                                State = "GA"
                            }
                        },
                        new Race()
                        {
                            Title = "Miami Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A beautiful marathon along the coast of Miami.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "789 Ocean Dr",
                                City = "Miami",
                                State = "FL"
                            }
                        },
                        new Race()
                        {
                            Title = "Chicago Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Experience the excitement of running through Chicago.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "101 Lake Shore Dr",
                                City = "Chicago",
                                State = "IL"
                            }
                        },
                        new Race()
                        {
                            Title = "Seattle Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A scenic marathon that showcases the beauty of Seattle.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "202 Pike St",
                                City = "Seattle",
                                State = "WA"
                            }
                        },
                        new Race()
                        {
                            Title = "Denver Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A challenging marathon at high altitude in the heart of Denver.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "303 Colfax Ave",
                                City = "Denver",
                                State = "CO"
                            }
                        },
                        new Race()
                        {
                            Title = "Boston Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "The world's oldest annual marathon, drawing elite runners and enthusiasts alike.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "404 Boylston St",
                                City = "Boston",
                                State = "MA"
                            }
                        },
                        new Race()
                        {
                            Title = "Portland Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "A marathon that celebrates the scenic beauty of Portland.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "505 N Williams Ave",
                                City = "Portland",
                                State = "OR"
                            }
                        },
                        new Race()
                        {
                            Title = "San Francisco Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "Run along the iconic waterfront of San Francisco.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "606 Embarcadero",
                                City = "San Francisco",
                                State = "CA"
                            }
                        },
                        new Race()
                        {
                            Title = "New York City Marathon",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "The largest marathon in the world, winding through all five boroughs.",
                            RaceCategory = RaceCategory.Marathon,
                            Address = new Address()
                            {
                                Street = "707 Central Park West",
                                City = "New York",
                                State = "NY"
                            }
                        }

                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin@email.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "admin.user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Test@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "alvin@test.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "alvin",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Test@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
