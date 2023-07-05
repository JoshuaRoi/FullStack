using ContactsAPI.Models.DTO;
using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Repositories;

namespace ContactsAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<Contact> GetContacts() =>  _contactRepository.GetAll().Result;
        
        public Contact GetContact(Guid Id) =>  _contactRepository.Get(Id).Result;
        public bool AddContact(ContactDTO contact) {
            Contact newContact = new()
            {
                Id = new Guid(),
                Address = contact.Address,
                Company = contact.Company,
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                IsFavorite = contact.IsFavorite,
                MobileNumber = contact.MobileNumber,
                NickName = contact.NickName
            };
            return _contactRepository.Add(newContact).Result;
        }
        public bool DeleteContact(Guid Id) => _contactRepository.Delete(Id).Result;

        public bool UpdateContact(Guid Id, ContactDTO contact) => _contactRepository.Update(Id, contact).Result;
    }
}
