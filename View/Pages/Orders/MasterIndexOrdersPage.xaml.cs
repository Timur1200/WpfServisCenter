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
    /// Логика взаимодействия для MasterIndexOrdersPage.xaml
    /// </summary>
    public partial class MasterIndexOrdersPage : Page
    {
        public MasterIndexOrdersPage()
        {
            InitializeComponent();
        }

        private void OrderInfoClick(object sender, RoutedEventArgs e)
        {
            var order = DGridOrder.SelectedItem as Заказ;
            PageNavigate.MainWindowFrame.Navigate(new MasterOrderInfoPage(order));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGridOrder.ItemsSource = ContextEF.GetContext().Заказ.Where(q=>q.Статус == (int)СтатусЗаказов.Отправлен).ToList();
        }
    }
}
