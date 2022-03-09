using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppProgrammering
{
    public partial class MainPage : ContentPage
    {
        public string test { get; set; }
        public string test1 { get; set; }
        public int counter { get; set; }
        public Color colour { get; set; }
        public Color colour2 { get; set; }
        public Color buttonTextColour { get; set; }
        public double sliderValue { get; set; }
        public double imageOpacity { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            test = "Hello :(";
            OnPropertyChanged("test");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            test1 = "Hello :D";
            OnPropertyChanged("test1");
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            counter += 1;
            OnPropertyChanged("counter");
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            if (colour == Color.Black)
            {
                colour = Color.White;
                OnPropertyChanged("colour");
                colour2 = Color.Black;
                OnPropertyChanged("colour2");
                buttonTextColour = Color.White;
                OnPropertyChanged("buttonTextColour");
            }else
            {
                colour = Color.Black;
                OnPropertyChanged("colour");
                colour2 = Color.White;
                OnPropertyChanged("colour2");
                buttonTextColour = Color.Black;
                OnPropertyChanged("buttonTextColour");
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            imageOpacity = sliderValue / 100;
            OnPropertyChanged("imageOpacity");
        }
    }
}