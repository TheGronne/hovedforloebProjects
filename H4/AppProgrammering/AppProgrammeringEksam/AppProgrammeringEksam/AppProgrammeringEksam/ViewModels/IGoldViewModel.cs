using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppProgrammeringEksam
{
    public interface IGoldViewModel
    {
        string _Gold { get; set; }
        string CritChance { get; set; }
        string CritDamage { get; set; }
        string Damage { get; set; }
        double HP { get; set; }
        ObservableCollection<Item> itemsource { get; }
        Color SquareColour { get; set; }
        string SquareImage { get; set; }

        void UpdateGold();
    }
}