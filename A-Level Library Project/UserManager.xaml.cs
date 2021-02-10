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

namespace A_Level_Library_Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class UserManager : Window
    {
        List<User> users = new List<User>();
        public UserManager()
        {
            InitializeComponent();
            DataAccess db = new DataAccess();
            users = db.GetUsers();
            UserListbox.ItemsSource = users;
            UserListbox.DisplayMemberPath = "Username";
            UserListbox.SelectedValuePath = "Id";
            
            
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void UserListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Selected = (int)UserListbox.SelectedValue;
            IdBox.Text = Selected.ToString();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            db.AddUser(ForenameBox.Text, SurnameBox.Text, UsernameBox.Text, PasswordBox.Text);
        }
    }
}
