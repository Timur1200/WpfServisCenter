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

namespace WpfServisCenter.View.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для IndexClientPage.xaml
    /// </summary>
    public partial class IndexClientPage : Page
    {
        public IndexClientPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridClient.ItemsSource = ContextEF.GetContext().Клиент.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigate.MainWindowFrame.Navigate(new AddEditClientPage(null));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            try
            {
                ContextEF.GetContext().Клиент.Remove(DGridClient.SelectedItem as Клиент);
                ContextEF.GetContext().SaveChanges();
                Page_Loaded(null,null);
            }
            catch
            {
                MessageBox.Show("Данную запись нельзя удалить");
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridClient.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            PageNavigate.MainWindowFrame.Navigate(new AddEditClientPage(DGridClient.SelectedItem as Клиент));
        }
    }
}
