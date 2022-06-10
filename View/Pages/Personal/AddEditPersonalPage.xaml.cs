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

namespace WpfServisCenter.View.Pages.Personal
{
    /// <summary>
    /// Логика взаимодействия для AddEditPersonalPage.xaml
    /// </summary>
    public partial class AddEditPersonalPage : Page
    {
        public AddEditPersonalPage(Персонал персонал)
        {
            InitializeComponent();
            EnumsRoliToList();
            if (персонал == null)
            {
                _Personal = new Персонал();
            }
            else
            {
                _Personal = персонал;
            }
            DataContext = _Personal;
        }
        private Персонал _Personal;
        List<Роли> Roles = new List<Роли>();
        void EnumsRoliToList()
        {
           

            Roles.Add(Роли.Сотрудник);
            Roles.Add(Роли.Мастер);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxRoles.ItemsSource = Roles;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            _Personal.Роль = ComboBoxRoles.SelectedIndex;
            if (!_Personal.IsValid())
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            if (_Personal.Код == 0) ContextEF.GetContext().Персонал.Add(_Personal);
            ContextEF.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            PageNavigate.Back();
        }
    }
}
