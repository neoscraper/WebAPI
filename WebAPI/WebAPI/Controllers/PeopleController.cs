using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();
        public PeopleController()
        {
            people.Add(new Person { FirstName = "Mario", LastName = "Mario", ID = 1 });
            people.Add(new Person { FirstName = "Sakata", LastName = "Gintoki", ID = 2 });
            people.Add(new Person { FirstName = "Bruce", LastName = "Wayne", ID = 3 });
        }

        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.ID == id).FirstOrDefault();
        }

        //Changes route, since there can't be multiple gets
        [Route("api/People/ListFirstNames")]
        //Shows type of HTTP request
        [HttpGet]
        public IEnumerable<String> ListFirstNames()
        {
            List<string> firstNames = new List<string>();

            foreach(Person p in people)
            {
                firstNames.Add(p.FirstName);
            }

            return firstNames;
        }

        [Route("api/People/NumberOfPeople")]
        [HttpGet]
        public int NumberOfPeople()
        {
            return people.Count;
        }

        // POST: api/People
        public void Post(Person person)
        {
            people.Add(person);
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            people.Remove(people.Where(x => x.ID == id).FirstOrDefault());
        }
    }
}
