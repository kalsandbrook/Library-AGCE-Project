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
    public partial class BookLoans : Window
    {
        List<Books> books = new List<Books>();
        public BookLoans()
        {
            InitializeComponent();
            DataAccess db = new DataAccess();
            books = db.GetBooks();
            bookList.ItemsSource = books;
            bookList.DisplayMemberPath = "Title";
            bookList.SelectedValuePath = "BookId";
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(bookList.SelectedIndex >= 0) // Enables buttons if an item is selected on the list.
            {
                btnLoan.IsEnabled = true;
                btnReserve.IsEnabled = true;
            }
            else
            {
                btnLoan.IsEnabled = false;
                btnLoan.IsEnabled = false;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu _mainMenu = new MainMenu();
            _mainMenu.Show();
            this.Close();
        }
    }
}
