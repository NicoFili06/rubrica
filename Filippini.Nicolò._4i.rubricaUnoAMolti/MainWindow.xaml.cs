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
        List<Persona> Persone = new List<Persona>();
        List<Contatto> Contatti = new List<Contatto>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Filippini_Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader fin = new StreamReader("persone.csv");
                fin.ReadLine();

                while (!fin.EndOfStream)
                {
                    string riga = fin.ReadLine();
                    Persona p = new Persona(riga);
                    Persone.Add(p);
                }
                dgPersone.ItemsSource = Persone;

                statusbar.Text = $"Ho letto {Persone.Count} righe";

                StreamReader fino = new StreamReader("contatti.csv");
                fino.ReadLine();

                while (!fino.EndOfStream)
                {
                    string riga = fino.ReadLine();
                    Contatto c = new Contatto(riga);
                    Contatti.Add(c);
                }
                dgContatti.ItemsSource = Contatti;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } private void dgPersone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;
            List<Contatto> contattiFiltrati = new List<Contatto>();
            if (p != null)
            {
                statusbar.Text = $"Il contatto selezionato: {p.Nome}";
                foreach (Contatto item in Contatti)
                {
                    if (item.idPersona == p.idPersona)
                    {
                        contattiFiltrati.Add(item);
                    }
                }
            }
            dgContatti.ItemsSource = contattiFiltrati;
        }
    }
}