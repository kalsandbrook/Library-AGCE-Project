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
    public partial class BookManager : Window
    {
        List<Books> books = new List<Books>();
        public BookManager()
        {
            InitializeComponent();
            DataAccess db = new DataAccess();
            books = db.GetBooks();
            bookList.ItemsSource = books;
            bookList.DisplayMemberPath = "Title";
            bookList.SelectedValuePath = "BookId";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu _MainMenu = new MainMenu();
            _MainMenu.Show();
            this.Close();
        }

        private void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
