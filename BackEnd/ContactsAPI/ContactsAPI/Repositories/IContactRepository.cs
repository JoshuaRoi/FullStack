using ContactsAPI.Models;
using ContactsAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsAPI.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Get(Guid Id);
        Task<bool> Add(Contact data);
        Task<bool> Delete(Guid Id);
        Task<bool> Update(Guid Id, ContactDTO newContact);
    }
}
