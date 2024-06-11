namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{

    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContactControl()
	{
		InitializeComponent();
	}

	public string Name
	{ 
		get 
		{
			return entryName.Text;
		}
		set
		{
			entryName.Text = value;
		} 
	}
    public string Address
    {
        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }
    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }
    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }
    public string Description
    {
        get
        {
            return entryDescription.Text;
        }
        set
        {
            entryDescription.Text = value;
        }
    }


    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
       OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);    
    }
}