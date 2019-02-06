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
	public partial class StartOffer : ContentPage
	{
		public StartOffer ()
		{
			InitializeComponent ();

            //Ratings
            List<string> Ratings = new List<string>();
            Ratings.Add("1 Star");
            Ratings.Add("2 Stars");
            Ratings.Add("3 Stars");
            Ratings.Add("4 Stars");

            //Set list as item source for picker
            RatePicker.ItemsSource = Ratings;
        }

        private async void PreviewBid(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BidReview());
        }

    }
}