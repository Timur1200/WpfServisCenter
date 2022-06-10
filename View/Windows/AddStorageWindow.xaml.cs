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
    /// Логика взаимодействия для AddStorageWindow.xaml
    /// </summary>
    public partial class AddStorageWindow : Window
    {
        public AddStorageWindow(Заказ заказ)
        {
            InitializeComponent();
            _списокМатериаловСклада = new СписокМатериаловСклада();
            _списокМатериаловСклада.КодЗаказа = заказ.Код;
            DataContext = _списокМатериаловСклада;

        }
        private СписокМатериаловСклада _списокМатериаловСклада { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServisComboBox.ItemsSource = ContextEF.GetContext().Склад.ToList();
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (kolvoTextBox.Text == "" || kolvoTextBox.Text == "0" || ServisComboBox.SelectedItem == null)
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            Склад storage = ServisComboBox.SelectedItem as Склад;
            if (storage.Количество < _списокМатериаловСклада.Количество)
            {
                MessageBox.Show("На складе недостаточно материала");
                return;
            }

            storage.Количество -= _списокМатериаловСклада.Количество;
            ContextEF.GetContext().СписокМатериаловСклада.Add(_списокМатериаловСклада);
            ContextEF.GetContext().SaveChanges();
            CompletOrderPage.Reload();
            this.Close();
        }

        private void TextoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text == "")
            {
                Window_Loaded(null,null);
                return;
            }
            ServisComboBox.IsDropDownOpen = true;
            string Text = TextBoxSearch.Text;
            ServisComboBox.ItemsSource = ContextEF.GetContext().Склад.Where(q=>q.Имя.Contains(Text)).ToList();

        }
    }
}
