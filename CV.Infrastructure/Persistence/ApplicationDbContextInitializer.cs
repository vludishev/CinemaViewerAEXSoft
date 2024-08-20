using CV.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CV.Infrastructure.Persistence
{
    public class ApplicationDbContextInitializer
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void Initialise()
        {
            try
            {
                if (_context.Database.IsSqlite())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }

        public void Seed()
        {
            try
            {
                if (_context.Database.CanConnect())
                {
                    TrySeed();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private void TrySeed()
        {
            if (!_context.Genres.Any())
            {
                _context.Genres.AddRange(GetPreconfiguredGenres());
                _context.SaveChanges();
            }

            if (!_context.Films.Any())
            {
                _context.Films.AddRange(GetPreconfiguredFilms());
                _context.SaveChanges();
            }

            if (!_context.Screenshots.Any())
            {
                _context.Screenshots.AddRange(GetPreconfiguredScreenshots());
                _context.SaveChanges();
            }

            if (!_context.Actors.Any())
            {
                _context.Actors.AddRange(GetPreconfiguredActors());
                _context.SaveChanges();
            }

            if (!_context.Photos.Any())
            {
                _context.Photos.AddRange(GetPreconfiguredPhotos());
                _context.SaveChanges();
            }

            if (!_context.FilmGenres.Any())
            {
                _context.FilmGenres.AddRange(GetPreconfiguredFilmGenres());
                _context.SaveChanges();
            }

            if (!_context.FilmActors.Any())
            {
                _context.FilmActors.AddRange(GetPreconfiguredFilmActors());
                _context.SaveChanges();
            }
        }

        private static List<Genre> GetPreconfiguredGenres()
        {
            return new List<Genre>
            {
                new Genre { Name = "Action", ImageUrl = "action.jpg" },
                new Genre { Name = "Horror", ImageUrl = "horror.jpg" },
                new Genre { Name = "Animation", ImageUrl = "animation.jpg" },
                new Genre { Name = "Comedy", ImageUrl = "comedy.jpg" },
                new Genre { Name = "Drama", ImageUrl = "drama.jpg" },
                new Genre { Name = "Romance", ImageUrl = "romance.jpg" }
            };
        }

        private static List<Film> GetPreconfiguredFilms()
        {
            return new List<Film>
            {
                new Film
                {
                    Name = "Dawn of the Dead",
                    Description = "A nurse, a policeman, a young married couple, a salesman and other survivors of a worldwide plague that is producing aggressive, flesh-eating zombies, take refuge in a mega Midwestern shopping mall.",
                    Rating = 7.3,
                    Year = "2004"
                },
                new Film
                {
                    Name = "SKAM",
                    Description = "The story of young teenagers and pupils on Hartvig Nissens upper secondary school in Oslo, and their troubles, scandals and everyday life. Each season is told from a different person's point...",
                    Rating = 8.6,
                    Year = "2015"
                },
                new Film
                {
                    Name = "American Dad!",
                    Description = "The escapades of Stan Smith, a conservative C.I.A. Agent dealing with family life, and keeping America safe.",
                    Rating = 7.4,
                    Year = "2005"
                }
            };
        }

        private static List<Screenshot> GetPreconfiguredScreenshots()
        {
            var screenshots = new List<Screenshot>
            {
                new Screenshot { FilmId = 1, ImageUrl = "dawn_of_the_dead_poster.jpg", IsPoster = true },
                new Screenshot { FilmId = 2, ImageUrl = "skam_poster.jpg", IsPoster = true },
                new Screenshot { FilmId = 3, ImageUrl = "american_dad_poster.jpg", IsPoster = true }
            };

            var additionalScreenshots = new List<Screenshot>
            {
                new Screenshot { FilmId = 1, ImageUrl = "dawn_of_the_dead_ss1.jpg" },
                new Screenshot { FilmId = 1, ImageUrl = "dawn_of_the_dead_ss2.jpg" },
                new Screenshot { FilmId = 2, ImageUrl = "skam_ss1.jpg" },
                new Screenshot { FilmId = 2, ImageUrl = "skam_ss2.jpg" },
                new Screenshot { FilmId = 2, ImageUrl = "skam_ss3.jpg" },
                new Screenshot { FilmId = 3, ImageUrl = "american_dad_ss1.jpg" },
                new Screenshot { FilmId = 3, ImageUrl = "american_dad_ss2.jpg" },
                new Screenshot { FilmId = 3, ImageUrl = "american_dad_ss3.jpg" }
            };

            screenshots.AddRange(additionalScreenshots);
            return screenshots;
        }

        private static List<Actor> GetPreconfiguredActors()
        {
            return new List<Actor>
            {
                new Actor
                {
                    FirstName = "Sarah",
                    LastName = "Polley",
                    Bio = "Sarah Polley is an actress and director renowned in her native Canada for her political activism. Blessed with an extremely expressive face that enables directors to minimize dialog due to her uncanny ability to suggest a character's thoughts, Polley has become a favorite of critics for her sensitive portraits of wounded and conflicted young women in independent films.",
                    Birthdate = new DateTime(1979, 1, 8)
                },
                new Actor
                {
                    FirstName = "Michael",
                    LastName = "Kelly",
                    Bio = "Michael was born in Philadelphia but raised in Lawrenceville, Georgia by parents Michael and Maureen Kelly. He has two sisters, Shannon and Casey, and one brother, Andrew. He went to college at Coastal Carolina University in South Carolina with the original intention to study law, but changed his mind after taking an acting elective. In addition to acting, Michael is a musician and very athletic. He is a lifetime member of the Actor's Studio. He now lives and works out of New York.\r\n- IMDb Mini Biography By: Taryn",
                    Birthdate = new DateTime(1969, 5, 22)
                },
                new Actor
                {
                    FirstName = "Inna",
                    LastName = "Korobkina",
                    Bio = "Inna Korobkina was born on 23 February 1981 in Magadan, Magadan region, RSFSR, USSR [now Russia]. She is an actress and producer, known for Dawn of the Dead (2004), Transformers: Dark of the Moon (2011) and The Mummy: Tomb of the Dragon Emperor (2008). She has been married to Steve Valentine since 28 August 2010. They have two children.",
                    Birthdate = new DateTime(1981, 2, 23)
                },
                new Actor
                {
                    FirstName = "Josefine Frida",
                    LastName = "Pettersen",
                    Bio = "Josefine Frida Pettersen was born on May 18, 1996 in Sigdal, Buskerud, Norway. She is an actress, known for Skam (2015), Disco (2019) and So Long Marianne (2023).",
                    Birthdate = new DateTime(1996, 5, 18)
                },
                new Actor
                {
                    FirstName = "Thomas",
                    LastName = "Hayes",
                    Bio = "Thomas Hayes is known for Skam (2015), Ingen Retur (2018) and The River (2017).",
                    Birthdate = new DateTime(1997, 3, 7)
                },
                new Actor
                {
                    FirstName = "Ulrikke",
                    LastName = "Falch",
                    Bio = "Ulrikke Falch is known for Skam (2015), Astronauter og filmstjerner (2016) and Karsten og Petra (2013).",
                    Birthdate = new DateTime(1996, 7, 17)
                },
                new Actor
                {
                    FirstName = "Seth",
                    LastName = "MacFarlane",
                    Bio = "Seth Woodbury MacFarlane was born in the small New England town of Kent, Connecticut, where he lived with his mother, Ann Perry (Sager), an admissions office worker, his father, Ronald Milton MacFarlane, a prep school teacher, and his sister, Rachael MacFarlane, now a voice actress and singer. He is of English, Scottish, and Irish ancestry, and descends from Mayflower passengers.",
                    Birthdate = new DateTime(1973, 10, 26)
                },
                new Actor
                {
                    FirstName = "Wendy",
                    LastName = "Schaal",
                    Bio = "Wendy Schaal is an American actress best known for her work in Joe Dante films such as Innerspace, The 'Burbs, and Small Soldiers. Since 2005, she has primarily worked in cartoon voice acting, most notably voicing Francine Smith in the animated comedy American Dad! Schaal was born in Chicago, Illinois, the daughter of Lois (née Treacy) and actor Richard Schaal (1928-2014). She is the former stepdaughter of actress Valerie Harper. Wendy Schaal is married to Michael P. Hogan.",
                    Birthdate = new DateTime(1954, 7, 2)
                },
                new Actor
                {
                    FirstName = "Scott",
                    LastName = "Grimes",
                    Bio = "Scott Christopher Grimes is an American actor and singer from Lowell, Massachusetts who is known for playing as Steve Smith from American Dad, Kevin Swanson from Family Guy, Will McCorkle from Party of Five, Bradley Brown from Critters 1 and 2 and Lieutenant Gordon Malloy from The Orville. He has two children.",
                    Birthdate = new DateTime(1971, 7, 9)
                }
            };
        }

        private static List<Photo> GetPreconfiguredPhotos()
        {
            return new List<Photo>
            {
                new Photo { ActorId = 1, ImageUrl = "sarah_polley.jpg" },
                new Photo { ActorId = 2, ImageUrl = "michael_kelly.jpg" },
                new Photo { ActorId = 3, ImageUrl = "inna_korobkina.jpg" },
                new Photo { ActorId = 4, ImageUrl = "josefine_frida_pettersen.jpg" },
                new Photo { ActorId = 5, ImageUrl = "thomas_hayes.jpg" },
                new Photo { ActorId = 6, ImageUrl = "ulrikke_falch.jpg" },
                new Photo { ActorId = 7, ImageUrl = "seth_macfarlane.jpg" },
                new Photo { ActorId = 8, ImageUrl = "wendy_schaal.jpg" },
                new Photo { ActorId = 9, ImageUrl = "scott_grimes.jpg" }
            };
        }

        private static List<FilmGenre> GetPreconfiguredFilmGenres()
        {
            return new List<FilmGenre>
            {
                new FilmGenre { FilmId = 1, GenreId = 1 },
                new FilmGenre { FilmId = 1, GenreId = 2 },
                new FilmGenre { FilmId = 2, GenreId = 1 },
                new FilmGenre { FilmId = 2, GenreId = 5 },
                new FilmGenre { FilmId = 2, GenreId = 6 },
                new FilmGenre { FilmId = 3, GenreId = 1 },
                new FilmGenre { FilmId = 3, GenreId = 3 },
                new FilmGenre { FilmId = 3, GenreId = 4 }
            };
        }

        private static List<FilmActor> GetPreconfiguredFilmActors()
        {
            return new List<FilmActor>
            {
                new FilmActor { FilmId = 1, ActorId = 1 },
                new FilmActor { FilmId = 1, ActorId = 2 },
                new FilmActor { FilmId = 1, ActorId = 3 },
                new FilmActor { FilmId = 2, ActorId = 4 },
                new FilmActor { FilmId = 2, ActorId = 5 },
                new FilmActor { FilmId = 2, ActorId = 6 },
                new FilmActor { FilmId = 3, ActorId = 7 },
                new FilmActor { FilmId = 3, ActorId = 8 },
                new FilmActor { FilmId = 3, ActorId = 9 }
            };
        }
    }
}
