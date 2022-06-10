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
    /// Логика взаимодействия для CompletOrderPage.xaml
    /// </summary>
    public partial class CompletOrderPage : Page
    {
        public CompletOrderPage(Заказ заказ)
        {
            InitializeComponent();
            thisPage = this;
            _Order = заказ;
            DataContext = _Order;
        }
        private Заказ _Order { get; set; }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ServisListBox.ItemsSource = ContextEF.GetContext().СписокМатериаловСклада.Where(q=>q.КодЗаказа == _Order.Код).ToList();
        }
        public static CompletOrderPage thisPage;
        public static void Reload()
        {
            thisPage.Page_Loaded(null, null);
        }
        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            _Order.Статус = (int)СтатусЗаказов.Завершен;
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Заказ завершен");
            PageNavigate.Back();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Windows.AddStorageWindow addStorageWindow = new Windows.AddStorageWindow(_Order);
            addStorageWindow.ShowDialog();
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            var qwer = ServisListBox.SelectedItem as СписокМатериаловСклада;
            Склад склад = ContextEF.GetContext().Склад.Where(q => q.Код == qwer.КодСклада).First();
            склад.Количество += qwer.Количество;
            ContextEF.GetContext().СписокМатериаловСклада.Remove(qwer);
            
            
            ContextEF.GetContext().SaveChanges();
            Page_Loaded(null, null);
        }
    }
}
