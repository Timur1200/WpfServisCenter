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

namespace WpfServisCenter.View.Pages.Orders
{
    /// <summary>
    /// Логика взаимодействия для IndexOrdersPage.xaml
    /// </summary>
    public partial class IndexOrdersPage : Page
    {
        public IndexOrdersPage()
        {
            InitializeComponent();
            TypeComboBox.Items.Add("Клиент");
           
            TypeComboBox.Items.Add("Техника");
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridOrder.ItemsSource = ContextEF.GetContext().Заказ.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigate.MainWindowFrame.Navigate(new AddEditOrderPage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
           var a = MySystem.CheckDataGrid(DGridOrder);
            if (a != null) PageNavigate.MainWindowFrame.Navigate(new AddEditOrderPage(a as Заказ));

        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            var a = MySystem.CheckDataGrid(DGridOrder);
            if (a != null) ContextEF.GetContext().Заказ.Remove(a as Заказ);
            ContextEF.GetContext().SaveChanges();
            Page_Loaded(null, null);
        }
        private void Search()
        {
            if (SearchTextBox.Text == "")
            {
                Page_Loaded(null, null);
                return;
            }
            if (TypeComboBox.SelectedIndex == 0)
            {
                DGridOrder.ItemsSource = ContextEF.GetContext().Заказ.
                    Where(q=>q.Клиент.Фио.Contains(SearchTextBox.Text)).ToList(); 
            }
            
            else
            {
                DGridOrder.ItemsSource = ContextEF.GetContext().Заказ.
                    Where(q => q.Техника.Contains(SearchTextBox.Text)).ToList();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }
    }
}
