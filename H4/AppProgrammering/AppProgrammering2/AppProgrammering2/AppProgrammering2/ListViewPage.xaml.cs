using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgrammering2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public string text { get; set; }
        private ObservableCollection<Person> liste = new ObservableCollection<Person>();
        public ObservableCollection<Person> itemsource { get { return liste; } }
        public int selectedItem;
        public ListViewPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            OnPropertyChanged("text");
            Person person = new Person(text);
            itemsource.Add(person);
        }
        private void Remove_Clicked(object sender, EventArgs e)
        {
            itemsource.RemoveAt(selectedItem);
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedItem = e.SelectedItemIndex;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        //string nickname { get; set; }

        public Person(string name/*, string nickname*/)
        {
            this.Name = name;
            //this.nickname = nickname;
        }
    }
}