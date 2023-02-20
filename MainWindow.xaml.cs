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
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            DoubleAnimation doubleAnimation= new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To=450;
            doubleAnimation.Duration=TimeSpan.FromSeconds(3);
            enterButton.BeginAnimation(Button.WidthProperty, doubleAnimation);
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            string password_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.ToLower();

            if (login.Length < 5)
            { 
                textBoxLogin.ToolTip = "This field is entered incorrectly";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                passBox.ToolTip = "This field is entered incorrectly";
                passBox.Background = Brushes.Red;
            }
            else if (password != password_2)
            {
                passBox_2.ToolTip = "This field is entered incorrectly";
                passBox_2.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "This field is entered incorrectly";
                textBoxEmail.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = ".";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Everything is correct");

                User user = new User(login, email, password);
                db.UsersDB.Add(user);
                db.SaveChanges();

                AuthWindow authWindow=new AuthWindow();
                authWindow.Show();
                Hide();

            }
        }

        private void ButtonAuthWindowClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow= new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
