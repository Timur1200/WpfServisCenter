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
    /// Логика взаимодействия для AddEditServisPage.xaml
    /// </summary>
    public partial class AddEditServisPage : Page
    {
        public AddEditServisPage(Услуги услуги)
        {
            InitializeComponent();
            if (услуги == null)
            {
                _Order = new Услуги();
            }
            else
            {
                _Order = услуги;
            }
            DataContext = _Order;
        }
        private Услуги _Order { get; set; } 
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (!_Order.IsValid())
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (_Order.Код == 0)
            {
                ContextEF.GetContext().Услуги.Add(_Order);
            }
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            PageNavigate.Back();
        }
    }
}
