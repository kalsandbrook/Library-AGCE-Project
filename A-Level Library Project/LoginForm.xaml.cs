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
using System.Configuration;
using System.Data.SqlClient;

namespace A_Level_Library_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class LoginForm : Window
    {
        public LoginForm()
        {

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            string givenUsername = txtUsername.Text;
            string givenPassword = txtPassword.Password;
            if(db.CheckLogin(givenUsername, givenPassword))
            {
                MainMenu _mainMenu = new MainMenu();
                _mainMenu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Login.");
            }
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckForBlanks();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckForBlanks();
        }
        private void CheckForBlanks()
        {
            if ((txtUsername == null) || (txtPassword == null)) // Checks if either field are blank, if so, disables the login button.
            {
                btnLogin.IsEnabled = false;
            }
            else // BROKEN
            {
                btnLogin.IsEnabled = true;
            }
        }
    }
}