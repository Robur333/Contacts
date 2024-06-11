using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;
namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	private readonly ContactDatabase database;
	public EditContactPage(ContactDatabase contactDatabase)
	{
		InitializeComponent();
		database = contactDatabase;	
	}

	public string ContactId { 
		set 
		{
            //contact = ContactRepository.GetContactById(int.Parse(value));
            //if( contact != null)
            //{
            //contactCtrl.Name = contact.Name;
            //             contactCtrl.Address = contact.Address;
            //             contactCtrl.Email = contact.Email;
            //             contactCtrl.Phone = contact.Phone;
            //}
            LoadContact(value);

        }
    }

    private async void LoadContact(string contactId)
    {
        int id = int.Parse(contactId);
        contact = await database.GetContactAsync(id);
        if (contact != null)
        {
            contactCtrl.Name = contact.Name;
            contactCtrl.Address = contact.Address;
            contactCtrl.Email = contact.Email;
            contactCtrl.Phone = contact.Phone;
            contactCtrl.Description = contact.Description;
        }
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        //contact.Name = contactCtrl.Name;
        //contact.Address = contactCtrl.Address;	
        //contact.Email = contactCtrl.Email;	
        //contact.Phone = contactCtrl.Phone;	

        //ContactRepository.UpdateContact(contact.ContactId, contact);
        //Shell.Current.GoToAsync("..");

        contact.Name = contactCtrl.Name;
        contact.Address = contactCtrl.Address;
        contact.Email = contactCtrl.Email;
        contact.Phone = contactCtrl.Phone;
        contact.Description = contactCtrl.Description;

        await database.SaveContactAsync(contact);
        await Shell.Current.GoToAsync("..");
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}