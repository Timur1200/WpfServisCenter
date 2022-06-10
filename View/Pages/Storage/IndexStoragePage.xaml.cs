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

namespace WpfServisCenter.View.Pages.Storage
{
    /// <summary>
    /// Логика взаимодействия для IndexStoragePage.xaml
    /// </summary>
    public partial class IndexStoragePage : Page
    {
        public IndexStoragePage()
        {
            InitializeComponent();
            


            TypeComboBox.Items.Add("Категория");
            TypeComboBox.Items.Add("Название");


        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           _StorageList = ContextEF.GetContext().Склад.ToList();
            DGridStorage.ItemsSource = _StorageList;
        }
        List<Склад> _StorageList { get; set; }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            PageNavigate.MainWindowFrame.Navigate(new AddEditStoragePage(null));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DGridStorage.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Склад a = DGridStorage.SelectedItem as Склад;
            PageNavigate.MainWindowFrame.Navigate(new AddEditStoragePage(a));
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (DGridStorage.SelectedItem == null)
            {
                MessageBox.Show("Нужно выбрать запись!");
                return;
            }
            Склад a = DGridStorage.SelectedItem as Склад;
            ContextEF.GetContext().Склад.Remove(a);
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
               DGridStorage.ItemsSource = ContextEF.GetContext().Склад.Where(q=>q.Категория.Contains(SearchTextBox.Text)).ToList();
            }
            else if (TypeComboBox.SelectedIndex == 1)
            {
                DGridStorage.ItemsSource = ContextEF.GetContext().Склад.Where(q => q.Имя.Contains(SearchTextBox.Text)).ToList();
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
