using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Controller for people. Allows user interact with people list and get information about it.
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();
        /// <summary>
        /// Starts the list with 3 people when starting up the project
        /// </summary>
        public PeopleController()
        {
            people.Add(new Person { FirstName = "Mario", LastName = "Mario", ID = 1 });
            people.Add(new Person { FirstName = "Sakata", LastName = "Gintoki", ID = 2 });
            people.Add(new Person { FirstName = "Bruce", LastName = "Wayne", ID = 3 });
        }

        /// <summary>
        /// Gets all the people in the list
        /// </summary>
        /// <returns>A Person Object for everyone in the people list</returns>
        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        /// <summary>
        /// Get a person by their id
        /// </summary>
        /// <param name="id">The id of the person</param>
        /// <returns>Returns the person based on the id</returns>
        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns a list of all the first names in the people list.
        /// </summary>
        /// <returns>Returns a List of strings with first names</returns>
        //Changes route, since there can't be multiple gets
        [Route("api/People/ListFirstNames")]
        //Shows type of HTTP request
        [HttpGet]
        public List<String> ListFirstNames()
        {
            List<string> firstNames = new List<string>();

            foreach(Person p in people)
            {
                firstNames.Add(p.FirstName);
            }

            return firstNames;
        }

        /// <summary>
        /// Returns the number of people in the people list
        /// </summary>
        /// <returns>Returs an int of the number of people</returns>
        [Route("api/People/NumberOfPeople")]
        [HttpGet]
        public int NumberOfPeople()
        {
            return people.Count;
        }

        /// <summary>
        /// Adds a person to the people list
        /// </summary>
        /// <param name="person">The person object being added to the list</param>
        // POST: api/People
        public void Post(Person person)
        {
            people.Add(person);
        }

        /// <summary>
        /// Changes the id of a person in the list
        /// </summary>
        /// <param name="oldID">The current id of the person</param>
        /// <param name="newID">The id to change to for the person</param>
        /// <returns></returns>
        [Route("api/People/ChangeID/{oldID:int}/{newID:int}")]
        [HttpPut]
        public Person ChangeID(int oldID, int newID)
        {
            //Checks to see if ID exists
            Person changePerson = people.Where(x => x.ID == oldID).FirstOrDefault();
            if(changePerson != null)
            {
                //Checks to see if ID is taken
                if (people.Where(x => x.ID == newID).FirstOrDefault() == null)
                {
                    changePerson.ID = newID; 
                }
            }
            return changePerson;    
        }

        /// <summary>
        /// Deletes people from the list by id.
        /// </summary>
        /// <param name="id">The id of which to delete the person</param>
        // DELETE: api/People/5
        public void Delete(int id)
        {
            people.Remove(people.Where(x => x.ID == id).FirstOrDefault());
        }
    }
}
