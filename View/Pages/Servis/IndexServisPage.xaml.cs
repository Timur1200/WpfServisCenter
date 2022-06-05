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
    /// Логика взаимодействия для IndexServisPage.xaml
    /// </summary>
    public partial class IndexServisPage : Page
    {
        public IndexServisPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridServis.ItemsSource = ContextEF.GetContext().Услуги.ToList();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridServis.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            PageNavigate.MainWindowFrame.Navigate(new AddEditServisPage(DGridServis.SelectedItem as Услуги));
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigate.MainWindowFrame.Navigate(new AddEditServisPage(null));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridServis.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            try
            {
                ContextEF.GetContext().Услуги.Remove(DGridServis.SelectedItem as Услуги);
            }
            catch
            {
                MessageBox.Show("Данную услугу нельзя удалить");
            }
        }
    }
}
