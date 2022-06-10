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

namespace WpfServisCenter.View.Pages.Storage
{
    /// <summary>
    /// Логика взаимодействия для AddEditStoragePage.xaml
    /// </summary>
    public partial class AddEditStoragePage : Page
    {
        public AddEditStoragePage(Склад склад)
        {
            InitializeComponent();
            var a = Enum.GetNames(typeof(Категория));
            CategoryComboBox.ItemsSource = a;
            if (склад == null)
            {
                _Storage = new Склад();
            }
            else
            {
                _Storage = склад;
            }
            DataContext = _Storage;
        }

        private Склад _Storage { get; set; }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (!_Storage.IsValid())
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }

            if (_Storage.Код == 0) ContextEF.GetContext().Склад.Add(_Storage);
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена!");
            PageNavigate.Back();
        }
    }
}
