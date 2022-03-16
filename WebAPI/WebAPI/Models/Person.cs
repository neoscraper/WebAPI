using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// A person with a first and last name and an ID.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Unique ID to identify a person.
        /// </summary>
        public int ID { get; set; } = 0;
        /// <summary>
        /// First name of person
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// Last name of person
        /// </summary>
        public string LastName { get; set; } = "";
    }
}