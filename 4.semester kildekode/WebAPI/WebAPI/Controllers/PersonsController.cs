using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PersonsController : ApiController
    {

        private readonly List<Person> persons = new List<Person>()
            {
                new Person(10, "Henaf", 20),
                new Person(10, "GET PERSONS", 20),

            };

        [HttpGet]
        public IHttpActionResult GetPersonById(int id)
        {
            Person person = new Person(id, "TEST GET PERSON BY ID", 20);
            return Ok(person);
                
        }

        [HttpGet]

        public IHttpActionResult GetPersons()
        {
            return Ok(persons);
        }

        [HttpPost]
        public IHttpActionResult AddPerson(Person p)
        {
            persons.Add(p);
            return Ok(persons);
        }
    }
}
