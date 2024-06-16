using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AplicationDbContextInitializer
    {
        private readonly ILogger<AplicationDbContextInitializer> _logger;
        private readonly ApplicationDbContext _context;

        public AplicationDbContextInitializer(ILogger<AplicationDbContextInitializer> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlite())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            if (!_context.Films.Any())
            {
                _context.Films.Add(new Film
                {
                    Title = "Dawn of the Dead",
                    Description = "A nurse, a policeman, a young married couple, " +
                        "a salesman and other survivors of a worldwide plague that is producing aggressive, " +
                        "flesh-eating zombies, take refuge in a mega Midwestern shopping mall.",
                    Rating = 7.3,
                    Actors =
                    {
                        new Actor {
                            FirstName = "Sarah",
                            LastName = "Polley",
                            Bio = "Sarah Polley is an actress and director renowned in her native Canada " +
                                "for her political activism. Blessed with an extremely expressive face that " +
                                "enables directors to minimize dialog due to her uncanny ability to suggest a " +
                                "character's thoughts, Polley has become a favorite of critics for her " +
                                "sensitive portraits of wounded and conflicted young women in independent films.",
                            Birthdate = new DateTime(1979, 1, 8),
                            Photo = []
                        },
                        new Actor {
                            FirstName = "Michael",
                            LastName = "Kelly",
                            Bio = "Michael was born in Philadelphia but raised in Lawrenceville, " +
                                "Georgia by parents Michael and Maureen Kelly. He has two sisters, " +
                                "Shannon and Casey, and one brother, Andrew. He went to college at " +
                                "Coastal Carolina University in South Carolina with the original " +
                                "intention to study law, but changed his mind after taking an acting " +
                                "elective. In addition to acting, Michael is a musician and very athletic. " +
                                "He is a lifetime member of the Actor's Studio. He now lives and works out " +
                                "of New York.\r\n- IMDb Mini Biography By: Taryn",
                            Birthdate = new DateTime(1969, 05, 22),
                            Photo = []
                        },
                        new Actor {
                            FirstName = "Inna",
                            LastName = "Korobkina",
                            Bio = "Inna Korobkina was born on 23 February 1981 in Magadan, " +
                                "Magadan region, RSFSR, USSR [now Russia]. She is an actress and producer, " +
                                "known for Dawn of the Dead (2004), Transformers: Dark of the Moon (2011) " +
                                "and The Mummy: Tomb of the Dragon Emperor (2008). " +
                                "She has been married to Steve Valentine since 28 August 2010. " +
                                "They have two children.",
                            Birthdate = new DateTime(1981, 2, 23),
                            Photo = []
                        },
                    },
                    Genres =
                    {
                        new Genre {
                            Name = "Action"
                        },
                        new Genre {
                            Name = "Horror"
                        }
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
