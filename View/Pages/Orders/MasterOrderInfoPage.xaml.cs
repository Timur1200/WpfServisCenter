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
    /// Логика взаимодействия для MasterOrderInfoPage.xaml
    /// </summary>
    public partial class MasterOrderInfoPage : Page
    {
        public MasterOrderInfoPage(Заказ заказ)
        {
            InitializeComponent();
            _Order = заказ;
            DataContext = _Order;
        }
       private Заказ _Order { get; set; }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            _Order.Персонал = Session.User;
            _Order.Статус = (int)СтатусЗаказов.Ремонтируется;
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Заказ получен!");
            PageNavigate.MainWindowFrame.Navigate(new MyOrderPage());
        }
    }
}
