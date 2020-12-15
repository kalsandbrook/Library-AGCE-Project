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
        /*
        User user1 = new User("Fred", "fred5", "user");
        User user2 = new User("Jeff", "jeff5", "user");
        User user3 = new User("Bob", "bob5", "user"); 
        */
        public LoginForm()
        {
            
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool success = HardcodedUsers.CheckLogin(txtUsername.Text.ToLower(), txtPassword.Password);
            if (success) 
            { 
                Console.WriteLine("Login Successful");
                MainMenu _MainMenu = new MainMenu(); // Init a main menu window
                _MainMenu.Show();
                this.Close();
            }
            else { Console.WriteLine("Login Unsuccessful"); }
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
    public class HardcodedUsers
    {
        public static bool CheckLogin(string givenUsername, string givenPassword)
        {
            int counter = 0;

            while (counter < usernames.Count)
            {
                if (usernames[counter] == givenUsername)
                {
                    if (passwords[counter] == givenPassword)
                    {
                        return (true);
                    }
                }
                counter++;
            }
            return (false);
        }
        private static List<string> usernames = new List<string> { "fred", "jeff", "bob" };
        private static List<string> passwords = new List<string> { "fred5", "jeff5", "bob5" };
    }
}
