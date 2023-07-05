using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Models;
using ContactsAPI.Models.DTO;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public IActionResult GetAll() => Ok(_contactService.GetContacts());


        // GET api/<controller>/5
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id) => Ok(_contactService.GetContact(Id));

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] ContactDTO newContact) {
            var create = _contactService.AddContact(newContact);
            return create ? Ok($"Created new contact") : BadRequest();
        } 

        // PUT api/<controller>/5
        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, [FromBody] ContactDTO newContact) {
            var update = _contactService.UpdateContact(Id, newContact);
            return update ? Ok($"Updated contact with Id = {Id}") : BadRequest();
        } 

        // DELETE api/<controller>/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id) {
            var delete= _contactService.DeleteContact(Id);
            return delete ? Ok($"Deleted contact with Id = {Id}") : NotFound();
        } 
    }
}
