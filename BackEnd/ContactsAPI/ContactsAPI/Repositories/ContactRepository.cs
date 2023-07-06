using ContactsAPI.Models;
using ContactsAPI.Models.DTO;
using ContactsAPI.Persistence;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _db;

        public ContactRepository(Context db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Contact>> GetAll() => await _db.Contacts.ToListAsync();

        public async Task<Contact> Get(Guid Id) => await _db.Contacts.FindAsync(Id);

        public async Task<bool> Add(Contact data)
        {
            try
            {
                await _db.Contacts.AddAsync(data);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(Guid Id, ContactDTO newContact)
        {
            try
            {
                var isFound = await _db.Contacts.FindAsync(Id);
                if (isFound is null) return false;

                isFound.Email = newContact.Email;
                isFound.FirstName = newContact.FirstName;
                isFound.LastName = newContact.LastName;
                isFound.Address = newContact.Address;
                isFound.NickName = newContact.NickName;
                isFound.Company = newContact.Company;
                isFound.IsFavorite = newContact.IsFavorite;
                isFound.MobileNumber = newContact.MobileNumber;
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var toDelete = await _db.Contacts.FindAsync(Id);
                if (toDelete is not null)
                {
                    _db.Contacts.Remove(toDelete);
                    await _db.SaveChangesAsync();
                }
                return true;
            }
            catch {
                return false;
            }
          
        }
    }
}

