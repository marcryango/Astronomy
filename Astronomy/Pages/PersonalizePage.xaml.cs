using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Astronomy.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalizePage : ContentPage
	{
		public PersonalizePage ()
		{
			InitializeComponent ();

            btnCancel.Clicked += BtnCancelClicked;
            btnSave.Clicked += BtnSaveClicked;

            if (Application.Current.Properties.ContainsKey("Name") && 
                    !string.IsNullOrEmpty(Application.Current.Properties["Name"].ToString()))
            {
                entryName.Text = (string)Application.Current.Properties["Name"];
            }
            if (Application.Current.Properties.ContainsKey("Icon") && 
                    !string.IsNullOrEmpty(Application.Current.Properties["Icon"].ToString()))
            {
                pickerIcon.SelectedItem = (string)Application.Current.Properties["Icon"];
            }
        }

        async void BtnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async void BtnSaveClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["Name"] = entryName.Text;
            Application.Current.Properties["Icon"] = pickerIcon.SelectedItem as string;

            await Application.Current.SavePropertiesAsync();

            await this.Navigation.PopModalAsync();
        }
    }
}