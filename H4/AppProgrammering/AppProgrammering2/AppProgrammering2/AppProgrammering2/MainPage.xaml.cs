using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppProgrammering2
{
    public partial class  MainPage
    {
        public Color colour { get; set; }
        public bool switchEnable { get; set; }
        public string entryText { get; set; }
        public string labelText { get; set; }
        public double width { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            colour = Color.Blue;
            OnPropertyChanged("colour");
        }

        private void Switch_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (switchEnable == true)
            {
                switchEnable = false;
                OnPropertyChanged("switchEnabled");
                colour = Color.Red;
                OnPropertyChanged("colour");
            } else
            {
                switchEnable = true;
                OnPropertyChanged("switchEnabled");
                colour = Color.Blue;
                OnPropertyChanged("colour");
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            OnPropertyChanged("entryText");
            labelText = entryText;
            OnPropertyChanged("labelText");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            width += 1;
            OnPropertyChanged("width");
        }
    }
}
