using System;
using System.Collections.Generic;
using System.IO;
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

namespace Filippini.Nicolò._4i.rubricaUnoAMolti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contatti contatti = new Contatti();
        Persone persone = new Persone();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contatti = new("contatti.csv");
            dataGridContatti.ItemsSource = contatti;
            persone = new("persone.csv");
            dataGridPersone.ItemsSource = persone;
        }
         private void dataGridPersone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;

            if (p != null)
            {
                statusBar.Text = $"hai selezionato {p.Nome} {p.Cognome}";

                Contatti contattifiltrati = new();
                foreach (var item in contatti)
                    if (item.IdPersona == p.IdPersona)
                        contattifiltrati.Add(item);
                dataGridContatti.ItemsSource = contattifiltrati;
            }
        }
        private void dataGridContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}