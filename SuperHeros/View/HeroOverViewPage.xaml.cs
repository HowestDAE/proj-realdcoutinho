using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperHeros.View
{
    /// <summary>
    /// Interaction logic for HeroOverViewPage.xaml
    /// </summary>
    public partial class HeroOverViewPage : Page
    {
        public HeroOverViewPage()
        {
            InitializeComponent();
        }

        private void Hero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // cast sender to listbox
            ListBox listBox = (ListBox)sender;

            if (listBox.SelectedIndex == -1)
                listBox.SelectedIndex = 0;
        }
    }
}
