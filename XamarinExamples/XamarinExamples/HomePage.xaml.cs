using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExamples.Model;
using XamarinExamples.View;

namespace XamarinExamples
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : MasterDetailPage
	{
        public List<DrawerMenuItem> MenuItemList { get; set; }

		public HomePage ()
		{
			InitializeComponent ();

            MenuItemList = new List<DrawerMenuItem>();

            var Page1 = new DrawerMenuItem() { MenuText = "Rotated Text", MenuIcon = "", TargetType = typeof(RotatedTextPage) };
            var Page2 = new DrawerMenuItem() { MenuText = "Rotated Text Colored", MenuIcon = "", TargetType = typeof(RotatedTextColorPage) };
            var Page3 = new DrawerMenuItem() { MenuText = "Rotate Text Event", MenuIcon = "", TargetType = typeof(RotationEventPage) };
            var Page4 = new DrawerMenuItem() { MenuText = "Rotate Text Event Binding", MenuIcon = "", TargetType = typeof(RotatingEventBinding) };
            var Page5 = new DrawerMenuItem() { MenuText = "Switch", MenuIcon = "", TargetType = typeof(SwitchPage) };
            var Page6 = new DrawerMenuItem() { MenuText = "Button Enabler", MenuIcon = "", TargetType = typeof(ButtonEnabler) };
            var Page7 = new DrawerMenuItem() { MenuText = "API Call (Weather)", MenuIcon = "", TargetType = typeof(APICallWeather) };

            MenuItemList.Add(Page1);
            MenuItemList.Add(Page2);
            MenuItemList.Add(Page3);
            MenuItemList.Add(Page4);
            MenuItemList.Add(Page5);
            MenuItemList.Add(Page6);
            MenuItemList.Add(Page7);

            DrawerMenuItemList.ItemsSource = MenuItemList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(RotatedTextPage)));
		}

        private void MenuItemList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (DrawerMenuItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
