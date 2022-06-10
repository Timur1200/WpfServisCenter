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
            TypeComBox.Items.Add("Номер телефона");
            TypeComBox.Items.Add("Фио");
            TypeComBox.Items.Add("Адрес");
        }
        List<Клиент> _ClientsList { get; set;} = new List<Клиент>(); 
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _ClientsList = ContextEF.GetContext().Клиент.ToList();
            DGridClient.ItemsSource = _ClientsList;
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

        private void Search()
        {
            if (SearchTextBox.Text == "")
            {
                Page_Loaded(null,null);
                return;
            }

            if(TypeComBox.SelectedIndex == 0)
            {
                DGridClient.ItemsSource = ContextEF.GetContext().Клиент.Where(q => q.Телефон.Contains(SearchTextBox.Text))
                    .ToList();
            }
          else if (TypeComBox.SelectedIndex == 1)
            {
                DGridClient.ItemsSource = ContextEF.GetContext().Клиент.Where(q => q.Фио.Contains(SearchTextBox.Text))
                    .ToList();
            }
            else
            {
                DGridClient.ItemsSource = ContextEF.GetContext().Клиент.Where(q => q.Адрес.Contains(SearchTextBox.Text))
                    .ToList();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void TypeComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
    }
}
