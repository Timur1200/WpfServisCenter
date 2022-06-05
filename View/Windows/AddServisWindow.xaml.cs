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
using System.Windows.Shapes;
using WpfServisCenter.View.Pages.Servis;

namespace WpfServisCenter.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddServisWindow.xaml
    /// </summary>
    public partial class AddServisWindow : Window
    {
        public AddServisWindow(СписокОказанияУслуг списокОказанияУслуг)
        {
            InitializeComponent();
            оказаниеУслуги = new ОказаниеУслуг();
            оказаниеУслуги.КодСпискаОказанияУслуг = списокОказанияУслуг.Код;
            DataContext = оказаниеУслуги;
        }
        private ОказаниеУслуг оказаниеУслуги { get; set; }

        private void TextoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (TextBoxSearch.Text == "")
            {
                Window_Loaded(null, null);
                return;
            }
            ServisComboBox.IsDropDownOpen = true;
            string Text = TextBoxSearch.Text;
            ServisComboBox.ItemsSource = ContextEF.GetContext().Услуги.Where(q => q.Имя.Contains(Text)).ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            ContextEF.GetContext().ОказаниеУслуг.Add(оказаниеУслуги);
            ContextEF.GetContext().SaveChanges();
            ListServisAddEditPage.ThisPage.Reload();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServisComboBox.ItemsSource = ContextEF.GetContext().Услуги.ToList();
        }
    }
}
