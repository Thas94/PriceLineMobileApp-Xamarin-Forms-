using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Priceline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FinalPage : ContentPage
	{
		public FinalPage ()
		{
			InitializeComponent ();
        }

        private async void directHome(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new Home());
        }
    }
}