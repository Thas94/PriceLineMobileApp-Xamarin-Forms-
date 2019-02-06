using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Priceline.Helpers;

namespace Priceline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}

        private async void OpenAccountPage(object sender, EventArgs e)
        {

            if(Settings.accessToken.Length > 0)
            {
                await Navigation.PushAsync(new UserAccount());
            }
            else
            {
                await Navigation.PushAsync(new Account());
            }
        }

        private async void StartOffer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OfferHome());
        }
    }
}