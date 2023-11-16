using MeasureAPIPerformance.Models;
using MethodTimer;
using Microsoft.AspNetCore.Mvc;


namespace MeasureAPIPerformance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly List<Author> authors = new List<Author>();

        public AuthorController()
        {
            authors.Add(new Author()
            {
                Id = 1,
                FirstName = "Joydip",
                LastName = "Kanjilal"
            });
            authors.Add(new Author()
            {
                Id = 2,
                FirstName = "Paul",
                LastName = "Smith"
            });
        }

        [Time]
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            Thread.Sleep(1000); // added this delay to see a difference
            return authors;
        }

        [Time]
        [HttpGet("{id}", Name = "Get")]
        public Author Get(int id)
        {
            return authors.Find(x => x.Id == id);
        }
    }
}
