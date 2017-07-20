using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExamples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchPage : ContentPage
    {
        public SwitchPage()
        {
            InitializeComponent();
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            ColoredLabel.TextColor = args.Value ? Color.Purple : Color.Green;
            DisplayLabel.Text = "The color is " + (args.Value ? "Purple" : "Green");
        }
    }
}
