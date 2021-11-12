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

namespace WpfApp1
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = passbox.Password.Trim();
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Поле введено не правильно";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passbox.ToolTip = "Поле введено не правильно";
                passbox.Background = Brushes.DarkRed;

            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                passbox.ToolTip = "";
                passbox.Background = Brushes.Transparent;
                User authuser=null;
                using (AppContext db = new AppContext())
                {
                    authuser = db.Users.Where(b=>b.Login==login &&b.Password==pass).FirstOrDefault();       
                }
                if (authuser != null)
                {
                    MessageBox.Show("Авторизація успішна");
                    UserPageWindow userPage = new UserPageWindow();
                    userPage.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Не коректно введені дані");

                }
            }
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
