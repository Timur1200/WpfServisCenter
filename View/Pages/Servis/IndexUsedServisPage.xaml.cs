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

namespace WpfServisCenter.View.Pages.Servis
{
    /// <summary>
    /// Логика взаимодействия для IndexUsedServisPage.xaml
    /// </summary>
    public partial class IndexUsedServisPage : Page
    {
        public IndexUsedServisPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           DGridUsedServis.ItemsSource = ContextEF.GetContext().СписокОказанияУслуг.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigate.MainWindowFrame.Navigate(new AddEditUsedServisPage());
        }

        private void GoServisClick(object sender, RoutedEventArgs e)
        {
            var a = DGridUsedServis.SelectedItem as СписокОказанияУслуг;
            if (a.Стоимость != null)
            {
                MessageBox.Show("Эту запись нельзя изменять");
                return;
            }
            PageNavigate.MainWindowFrame.Navigate(new ListServisAddEditPage(a));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridUsedServis.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            var a = DGridUsedServis.SelectedItem as СписокОказанияУслуг;
            if (a.Стоимость != null)
            {
                MessageBox.Show("Эту запись нельзя удалить");
                return;
            }
            ContextEF.GetContext().СписокОказанияУслуг.Remove(a);
            ContextEF.GetContext().SaveChanges();
            Page_Loaded(null , null);
        }
    }
}
