using ContactsAPI.Models;
using ContactsAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(Guid Id);
        bool AddContact(ContactDTO contact);
        bool UpdateContact(Guid Id,ContactDTO contact);
        bool DeleteContact(Guid Id);
    }
}
