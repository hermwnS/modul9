using Microsoft.AspNetCore.Mvc;

namespace MOD9_1302213080.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        List<string> Stars1 = new List<string>
        {
            "Tim Robbins", 
            "Morgan Freeman", 
            "Bob Gunton", 
            "William Sadler"
        };
        List<string> Stars2 = new List<string>
        {
            "Marlon Brando",
            "Al Pacino",
            "James Caan",
            "Diane Keaton"
        };
        List<string> Stars3 = new List<string>
        {
            "Shameik Moore",
            "Hailee Steinfeld",
            "Brian Tyree Henry",
            "Luna Lauren Velez"
        };
        private static List<Movie> film = new List<Movie>
        {
            new Movie("The Shawshank Redemption","Frank Darabont",List<string>
                ("Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler"),
                "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion."),
            new Movie("The Godfather","Francis Ford Coppola",List<string>
                ("Marlon Brando","Al Pacino","James Caan","Diane Keaton"),
                "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. " +
                "However, his decision unintentionally puts the lives of his loved ones in grave danger."),
            new Movie("Spider-Man: Across the Spider-Verse",("Joaquim Dos Santos","Kemp Powers","Justin K. Thompson"),
                List<string> ("Shameik Moore","Hailee Steinfeld","Brian Tyree Henry","Luna Lauren Velez"),"Miles Morales catapults across the Multiverse, where he encounters a team of Spider-People charged with " +
                "protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero."),
        };

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMovie")]
        public IEnumerable<Movie> Get()
        {
            return film;
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return film[id];
        }

        [HttpPost()]
        public void Post([FromBody] Movie value)
        {
            film.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie value)
        {
            film[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            film.RemoveAt(id);
        }
    }
}