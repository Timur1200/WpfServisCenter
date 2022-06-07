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

namespace WpfServisCenter.View.Pages.Personal
{
    /// <summary>
    /// Логика взаимодействия для IndexPersonalPage.xaml
    /// </summary>
    public partial class IndexPersonalPage : Page
    {
        public IndexPersonalPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           DGridPersonal.ItemsSource = ContextEF.GetContext().Персонал.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigate.MainWindowFrame.Navigate(new AddEditPersonalPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        { 
            if (DGridPersonal.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            var personal = DGridPersonal.SelectedItem as Персонал;
            PageNavigate.MainWindowFrame.Navigate(new AddEditPersonalPage(personal));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridPersonal.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            var personal = DGridPersonal.SelectedItem as Персонал;
            ContextEF.GetContext().Персонал.Remove(personal);
            ContextEF.GetContext().SaveChanges();
            Page_Loaded(null, null);
        }
    }
}
