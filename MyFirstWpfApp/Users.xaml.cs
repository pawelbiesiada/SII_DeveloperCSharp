using CSharpConsole.Exercises;
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

namespace MyFirstWpfApp
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
        }

        private void cbxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbx = sender as ComboBox;
            if (cbx is null)
                return;

            var selectedElement = (User)cbx.SelectedItem;

            grdUsers.SelectedItem = selectedElement;

            txtId.Text = selectedElement.Id.ToString();
            txtName.Text = selectedElement.Name;
            txtIsActive.Text = selectedElement.IsActive.ToString();
            txtPassword.Text = selectedElement.Password;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var users = CreateCollection.GetUsers()
                .Where(u => u is not null)
                .OrderBy(u => u.Id)
                .ToArray();

            cbxUsers.ItemsSource = users;
            grdUsers.ItemsSource = users;


            cbxUsers.SelectedItem = cbxUsers.ItemsSource.OfType<User>().FirstOrDefault();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            var testMainView = new MainWindow();
            testMainView.ShowDialog();

            if(!string.IsNullOrEmpty(testMainView.SelectedName))
            {
                MessageBox.Show(testMainView.SelectedName);
            }
        }

        private void grdUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxUsers.SelectedItem = grdUsers.SelectedItem;
        }
    }
}
