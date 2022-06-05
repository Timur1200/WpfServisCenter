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
    /// Логика взаимодействия для AddEditUsedServisPage.xaml
    /// </summary>
    public partial class AddEditUsedServisPage : Page
    {
        public AddEditUsedServisPage()
        {
            InitializeComponent();
            _ListServis = new СписокОказанияУслуг();
            DataContext = _ListServis;
        }
        private СписокОказанияУслуг _ListServis { get; set; }
        private void TextBoxClientSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxClientSearch.Text == "")
            {
                ClientComboBox.ItemsSource = ContextEF.GetContext().Клиент.ToList();
                ClientComboBox.SelectedItem = null;
                return;
            }
            ClientComboBox.IsDropDownOpen = true;
            string Text = TextBoxClientSearch.Text;

            ClientComboBox.ItemsSource = ContextEF.GetContext().Клиент.Where(q => q.Фио.ToLower().Contains(Text.ToLower())).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientComboBox.ItemsSource = ContextEF.GetContext().Клиент.ToList();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_ListServis.Код == 0)
            {
                _ListServis.Дата = DateTime.Now;
                ContextEF.GetContext().СписокОказанияУслуг.Add(_ListServis);
            }
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            PageNavigate.Back();
        }
    }
}
