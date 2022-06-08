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
using System.Diagnostics;

namespace WpfServisCenter.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DNSwindow.xaml
    /// </summary>
    public partial class DNSwindow : Window
    {
        public DNSwindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a899cd16404e77/processory/");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a89a0416404e77/materinskie-platy/");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a89aab16404e77/videokarty/");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/2d514a593baa7fd7/operativnaya-pamyat/");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a89c2216404e77/bloki-pitaniya/");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a89c5616404e77/korpusa/");
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a9bdaf16404e77/oxlazhdenie-kompyutera/");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/789e55fe3bad7fd7/ssd-nakopiteli/");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/9d1ae3293bac7fd7/zhestkie-diski/");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.dns-shop.ru/catalog/17a9cccc16404e77/termointerfejsy/");
        }

        
    }
}
