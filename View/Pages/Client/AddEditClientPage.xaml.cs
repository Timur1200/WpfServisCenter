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

namespace WpfServisCenter.View.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientPage.xaml
    /// </summary>
    public partial class AddEditClientPage : Page
    {
        public AddEditClientPage(Клиент клиент)
        {
            InitializeComponent();
            if (клиент == null)
            {
                _client = new Клиент(); 
            }
            else
            {
                _client = клиент;
            }
            DataContext = _client;
        }

        private Клиент _client { get; set; }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (_client.Код == 0)
            {
                ContextEF.GetContext().Клиент.Add(_client);
            }
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            PageNavigate.Back();
        }
    }
}
