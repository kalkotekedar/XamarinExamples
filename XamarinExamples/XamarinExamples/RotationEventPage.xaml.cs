using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExamples
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RotationEventPage : ContentPage
	{
		public RotationEventPage ()
		{
			InitializeComponent ();
		}

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
            RotatingLabel.Rotation = (double)args.NewValue;
            SliderValueDisplay.Text = String.Format("Rotation = {0:F2} degrees", args.NewValue);
        }
    }
}
