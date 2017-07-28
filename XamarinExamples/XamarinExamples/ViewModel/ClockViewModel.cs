using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinExamples.ViewModel
{
    class ClockViewModel : INotifyPropertyChanged
    {
        DateTime dateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
                }
            }

            get
            {
                return dateTime;
            }
        }
    }
}
