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

namespace WpfServisCenter.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            List<Персонал> Personal = ContextEF.GetContext().Персонал.ToList();
            foreach(var person in Personal)
            {
                if (TBoxPhone.Text == person.Телефон && PassBox.Password == person.Пароль)
                {
                    Session.User = person; 
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Пользователь не найден");
        }
    }
}
