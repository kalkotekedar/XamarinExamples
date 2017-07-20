using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinExamples
{
	public partial class ExamplesHome : ContentPage
	{
		public ExamplesHome()
		{
			InitializeComponent();
		}

        private void RotatedClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RotatedTextPage());
        }

        private void RotatedColorClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new RotatedTextColorPage());
        }

        private void RotationEventClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new RotationEventPage());
        }

        private void RotationEventBindingClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new RotatingEventBinding());
        }

        private void SwitchClicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SwitchPage());
        }

        private void SwitchBindingClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ButtonEnabler());
        }
    }
}