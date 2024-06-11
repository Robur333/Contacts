namespace Contacts.Maui.Views;
using Contact = Contacts.Maui.Models.Contact;
using Contacts.Maui.Models;
using System.Collections.ObjectModel;

public partial class ContactsPage : ContentPage
{
    private readonly ContactDatabase database;

	public ContactsPage(ContactDatabase contactDatabase)
	{
		InitializeComponent();
        database = contactDatabase;
		
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SearchBar.Text = string.Empty;
        LoadContacts();
    }

    private async void listConctacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if(listConctacts.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listConctacts.SelectedItem).ContactId}");
		}
    }

    private void listConctacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listConctacts.SelectedItem = null;


    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
        await database.DeleteContactAsync(contact);
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = await database.GetContactsAsync();
        listConctacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var filterString = e.NewTextValue;
        var contacts = await database.SearchContactsAsync(filterString);
        listConctacts.ItemsSource = contacts;

    }


}