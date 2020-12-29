using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Payer payer;
        ObservableCollection<Payer> collection = new ObservableCollection<Payer>();

        public MainWindow()
        {
            payer = new Payer();
            InitializeComponent();
            stackpanelPayer.DataContext = payer;
            listBox.DataContext = collection;
        }

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(payer.ToString());
            collection.Clear();
            foreach (var p in Payer.GetAllPayers())
            {
                collection.Add(p);
            }

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //collection.Add(payer);
            payer.Insert();
            FillData();

        }

        private void FillData()
        {
            collection.Clear();
            foreach (var p in Payer.GetAllPayers())
            {
                collection.Add(p);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Payer)listBox.SelectedItem).Id;
            Payer.Delete(id);
            FillData();
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            string str = textBoxName.Text;
            payer = Payer.Find(str);
            if (payer == null)
                MessageBox.Show("Запись не найдена!");
            else
                MessageBox.Show(payer.ToString());
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            payer.Id = ((Payer)listBox.SelectedItem).Id;
            if (textBoxName.Text.Length > 0)
                payer.Name = textBoxName.Text;
            else
                payer.Name = ((Payer)listBox.SelectedItem).Name;
            decimal h = Convert.ToDecimal(textBoxHol.Text);
            if (h != 0)
                payer.Hol = h;
            else
                payer.Hol = ((Payer)listBox.SelectedItem).Hol;
            decimal g = Convert.ToDecimal(textBoxGor.Text);
            if (g != 0)
                payer.Gor = g;
            else
                payer.Gor = ((Payer)listBox.SelectedItem).Gor;
            payer.Update();
            FillData();
        }
    }
}
