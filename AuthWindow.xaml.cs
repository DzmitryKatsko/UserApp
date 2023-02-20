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

namespace UserApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();

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
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = ".";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext context = new ApplicationContext())
                {
                    authUser = context.UsersDB.Where(users => users.Login == login && users.Password == password).FirstOrDefault();
                }
                if (authUser!= null) 
                {
                    MessageBox.Show("Everything is correct");
                    UserPageWindow userPageWindow= new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("User does not exist");
                }
                
            }
        }

        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow= new MainWindow();
            UserPageWindow userPageWindow= new UserPageWindow();
            userPageWindow.Show();
            Hide();
        }
    }
}
