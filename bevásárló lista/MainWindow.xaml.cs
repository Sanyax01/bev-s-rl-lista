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

namespace bevásárló_lista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        int szam = 0;
        public MainWindow()
        {
            InitializeComponent();
            Blista.ItemsSource = items;
        }

        private void Ghozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (ItemBox.Text != "")
            {
                string item = ItemBox.Text;
                items.Add(item);
                ItemBox.Clear();
                Blista.Items.Refresh();
                
            }
            else
            {
                MessageBox.Show("A termék neve nem lehet üres!");
            }
            Label_ContentUpdate();
        }
        private void Torles(object sender, RoutedEventArgs e)
        {
            string torlesreKivalasztott = "" +Blista.SelectedItem;
            if (torlesreKivalasztott != "")
            {
                items.Remove(torlesreKivalasztott);
                Blista.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva termék!");
            }
            Label_ContentUpdate();
        }

        private void MindenTorol(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Biztosan kivánja törölni a bevásárló lista összes elemét?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                items.Clear();
                Blista.Items.Refresh();
            }
            Label_ContentUpdate();
        }

        private void Label_ContentUpdate()
        {
            szam = items.Count;
            Label1.Content = $"Összesen: {szam} db"; 
        }
    }
}