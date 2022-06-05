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
    /// Логика взаимодействия для AddEditOrderPage.xaml
    /// </summary>
    public partial class AddEditOrderPage : Page
    {
        public AddEditOrderPage(Заказ заказ)
        {
            InitializeComponent();
            if (заказ == null)
            {
                _Order = new Заказ();
            }
            else
            {
                _Order = заказ;
            }
            DataContext = _Order;
        }
        private Заказ _Order { get; set; }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientBox.ItemsSource = ContextEF.GetContext().Клиент.ToList();
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_Order.Код == 0)
            {
                _Order.ДатаПоступления = DateTime.Now;
                _Order.Статус = (int?)СтатусЗаказов.Отправлен;
                ContextEF.GetContext().Заказ.Add(_Order);
            }
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            PageNavigate.Back();
        }

        private void TBoxClientSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxClientSearch.Text == "")
            {
                ClientBox.ItemsSource = ContextEF.GetContext().Клиент.ToList();
                ClientBox.SelectedItem = null;
                return;
            }
            ClientBox.IsDropDownOpen = true;
            string Text = TBoxClientSearch.Text;

            ClientBox.ItemsSource = ContextEF.GetContext().Клиент.Where(q=>q.Фио.ToLower().Contains(Text.ToLower())).ToList();
        }
    }
}
