using Contacts.Maui.Models;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{

   private readonly ContactDatabase database;
	public AddContactPage(ContactDatabase contactDatabase)
	{
		InitializeComponent();
        database = contactDatabase;
	}

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"..");
    }

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {
        await database.SaveContactAsync(new Models.Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address,
            Description = contactCtrl.Description,  
        });

        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address,
            Description = contactCtrl.Description,  
        });
        Shell.Current.GoToAsync($"..");

    }
}