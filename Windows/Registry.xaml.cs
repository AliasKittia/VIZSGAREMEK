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
using System.Windows.Shapes;

namespace Karbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        Menu Menuablak;
        public Registry()
        {
            InitializeComponent();
        }

        private void VisszaBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrySaveBTN_Click(object sender, RoutedEventArgs e)
        {
            Menuablak = new Menu();
            Menuablak.Show();
            Close();
        }
    }
}
