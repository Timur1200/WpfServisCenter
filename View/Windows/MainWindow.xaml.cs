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
using WpfServisCenter.View.Pages.Client;
using WpfServisCenter.View.Pages.Orders;
using WpfServisCenter.View.Pages.Personal;
using WpfServisCenter.View.Pages.Servis;
using WpfServisCenter.View.Pages.Storage;

namespace WpfServisCenter.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageNavigate.MainWindowFrame = MainFrame;
            if (Session.User.Роль == (int)Роли.Сотрудник)
            {
                AdminPanel.Visibility = Visibility.Visible;
                MasterPanel.Visibility = Visibility.Collapsed;
            }
            else if (Session.User.Роль == (int)Роли.Мастер)
            {
                AdminPanel.Visibility = Visibility.Collapsed;
                MasterPanel.Visibility = Visibility.Visible;
            }
            TextBlock1.Text = $"Ваша роль: {(Роли)Session.User.Роль}";
        }

        private void Go(Page p)
        {
            MainFrame.Navigate(p);  
        }

        private void ClientClick(object sender, RoutedEventArgs e)
        {
            Go(new IndexClientPage());
        }

        private void ServisClick(object sender, RoutedEventArgs e)
        {
            Go(new IndexServisPage());
        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            Go(new IndexOrdersPage());
        }

        private void LeaveClick(object sender, RoutedEventArgs e)
        {
            LoginWin loginWin = new LoginWin();
            loginWin.Show();
            this.Close();
        }

        private void NewOrdersClick(object sender, RoutedEventArgs e)
        {
            Go(new MasterIndexOrdersPage());
        }

        private void MyOrdersClick(object sender, RoutedEventArgs e)
        {
            Go(new MyOrderPage());
        }

        private void CompletedOrderClick(object sender, RoutedEventArgs e)
        {
            Go(new ReadyOrdersPage());
        }

        private void UsedServisClick(object sender, RoutedEventArgs e)
        {
            Go(new IndexUsedServisPage());
        }

        private void PersonalClick(object sender, RoutedEventArgs e)
        {
            Go(new IndexPersonalPage());
        }


        private void ZakazClick(object sender, RoutedEventArgs e)
        {
            DNSwindow dNSwindow = new DNSwindow();
            dNSwindow.Show();
        }

        private void StorageClick(object sender, RoutedEventArgs e)
        {
            Go(new IndexStoragePage());
        }
    }
}
