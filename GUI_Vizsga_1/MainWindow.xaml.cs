using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Vizsga_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Controller.Ini("vasarlas");
        }

        private void BListElemKijelzese(BevasarloListaElem elem)
        {
            BListElements.Items.Add($"{elem.termek_id.nev}, {elem.mennyiseg}, {elem.mertekegyseg_id.nev}, {elem.uzlet_id.nev}, {elem.megvan}");
        }

        private static List<BevasarloListaElem> BevasarloListaElements = new List<BevasarloListaElem>();

        private void Szures_Click(object sender, RoutedEventArgs e)
        {
            BevasarloListaElements.Clear();
            for (int i = 0; i < B.Lista().Count; i++)
            {
                if (TermekNevCB.SelectedIndex != -1)
                {
                    if (B.Lista()[i].termek_id.nev == TermekNevCB.SelectedItem && ! BevasarloListaElements.Contains((B.Lista()[i])))
                    {
                        BevasarloListaElements.Add(B.Lista()[i]);
                    }
                }

                if (UzletCB.SelectedIndex != -1)
                {
                    if (B.Lista()[i].uzlet_id.nev == UzletCB.SelectedItem && ! BevasarloListaElements.Contains((B.Lista()[i])))
                    {
                        BevasarloListaElements.Add(B.Lista()[i]);
                    }
                }

                if (MegvasarolvasCB.SelectedIndex != -1)
                {
                    bool megvane = MegvasarolvasCB.SelectedItem == "TRUE" ? true : false; 
                    if (megvane && !BevasarloListaElements.Contains((B.Lista()[i])))
                    {
                        BevasarloListaElements.Add(B.Lista()[i]);
                    }
                }
            }

            BListElements.Items.Clear();
            for (int i = 0; i < BevasarloListaElements.Count; i++)
            {
                BListElemKijelzese(BevasarloListaElements[i]);
            }
        }

        private void UjTermek_Click(object sender, RoutedEventArgs e)
        {
            UjTermekHozzaadasa ujTermekHozzaadasa = new UjTermekHozzaadasa();
            ujTermekHozzaadasa.Show();
        }

        private void Megvasarlova_Click(object sender, RoutedEventArgs e)
        {
            MegvasarolvaWindow megvasarolvaWindow = new MegvasarolvaWindow(BevasarloListaElements[BListElements.SelectedIndex]);
            megvasarolvaWindow.Show();
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            SQL.Command($"DELETE FROM `bevasarlolista` WHERE id = {BevasarloListaElements[BListElements.SelectedIndex].ID}");
            MessageBox.Show("A bevásárló lista sikeresen ki lett törölve!", "Sikeres művelet", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}