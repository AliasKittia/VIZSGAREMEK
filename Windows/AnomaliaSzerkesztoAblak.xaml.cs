using Newtonsoft.Json;
using ProjectName_Backend.DTOs;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Karbantarto.Windows
{
    public partial class AnomaliaSzerkesztoAblak : Window
    {
        private AnomaliaLekeresDTO anomalia;

        public AnomaliaSzerkesztoAblak(AnomaliaLekeresDTO anomalia)
        {
            InitializeComponent();
            this.anomalia = anomalia;
            NevTBX.Text = anomalia.AnomalyName;
            HatasTBX.Text = anomalia.AnomalyEffect;
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
