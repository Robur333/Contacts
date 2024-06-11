using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public class ContactDatabase
    {
        SQLiteAsyncConnection Database;

        public ContactDatabase()
        {

        }

        async Task Init()
        {
            if(Database is not null)
            {
                return;
            }
            Database = new SQLiteAsyncConnection(Constants.DatabasePath);
            var result = await Database.CreateTableAsync<Contact>();
        }


        public async Task<List<Contact>> GetContactsAsync()
        {
            await Init();
            return await Database.Table<Contact>().ToListAsync();
        }


        public async Task<Contact> GetContactAsync(int contactId)
        {
            await Init();
            return await Database.Table<Contact>().Where(c => c.ContactId == contactId).FirstOrDefaultAsync();
        }

        public async Task<int> SaveContactAsync(Contact contact)
        {
            await Init();
            if (contact.ContactId != 0)
            {
                return await Database.UpdateAsync(contact);
            }
            else
            {
                return await Database.InsertAsync(contact);
            }
        }

        public async Task<int> DeleteContactAsync(Contact contact)
        {
            await Init();
            return await Database.DeleteAsync(contact);
        }
        public async Task<List<Contact>> SearchContactsAsync(string filterString)
        {
            await Init();

            // Preprocess the filterString to ensure it is not null or whitespace
            filterString = filterString?.Trim();

            if (string.IsNullOrWhiteSpace(filterString))
            {
                // If the filterString is null or whitespace, return all contacts
                return await GetContactsAsync();
            }

            // Perform the search across all fields
            var contacts = await Database.Table<Contact>()
                .Where(x => x.Name.StartsWith(filterString, StringComparison.OrdinalIgnoreCase) ||
                            x.Email.StartsWith(filterString, StringComparison.OrdinalIgnoreCase) ||
                            x.Phone.StartsWith(filterString, StringComparison.OrdinalIgnoreCase) ||
                            x.Address.StartsWith(filterString, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            return contacts;
        }

    }
}
