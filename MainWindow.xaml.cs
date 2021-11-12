using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(2);
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = passbox.Password.Trim();
            string passres = passboxres.Password.Trim();
            string email = TextBoxEmail.Text.Trim().ToLower();


            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Поле введено не правильно";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length<5)
            {
                passbox.ToolTip = "Поле введено не правильно";
                passbox.Background = Brushes.DarkRed;

            }
            else if (pass!=passres)
            {
                passboxres.ToolTip = "Паролі не співпадають";
                passboxres.Background = Brushes.DarkRed;
            }
            else if (email.Length<5|| !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Не коректний email";
                TextBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;

                passbox.ToolTip = "";
                passbox.Background = Brushes.Transparent;

                passboxres.ToolTip = "";
                passboxres.Background = Brushes.Transparent;

                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Реєстрація успішна!");
                User user = new User(login,pass,email);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }

        }
        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }

    }


}
