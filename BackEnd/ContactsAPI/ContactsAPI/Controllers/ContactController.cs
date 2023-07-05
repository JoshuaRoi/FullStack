using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Models;
using ContactsAPI.Models.DTO;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Contact> GetAll() => _contactService.GetContacts();


        // GET api/<controller>/5
        [HttpGet("{Id}")]
        public Contact Get(Guid Id) => _contactService.GetContact(Id);

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] ContactDTO newContact) => _contactService.AddContact(newContact);

        // PUT api/<controller>/5
        [HttpPut("{Id}")]
        public void Put(Guid Id, [FromBody] ContactDTO newContact) => _contactService.UpdateContact(Id,newContact);

        // DELETE api/<controller>/5
        [HttpDelete("{Id}")]
        public void Delete(Guid Id) => _contactService.DeleteContact(Id);
    }
}
