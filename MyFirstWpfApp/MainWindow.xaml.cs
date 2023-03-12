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

namespace MyFirstWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _names = new[] { "John", "Joe", "Peter", "Matt" }; 


        public string SelectedName 
        { 
            get 
            {
                if(cbxNames != null && cbxNames.SelectedItem != null && cbxNames.Items.Contains("")) // => OK
                //if (cbxNames.SelectedItem != null && cbxNames != null) // => NOT OK
                {
                    return cbxNames.SelectedItem.ToString() ?? "";  // ?? -> null coalescing
                }


                return cbxNames?.SelectedItem?.ToString() ?? "";   // ? -> null propagator
            } 
        }



        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text += txtDescrption.Text + Environment.NewLine;
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(this);
            txtPosition.Text = $"({position.X},{position.Y})";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxNames.ItemsSource = _names;
            cbxNames.SelectedItem = _names[0];
            
        }

        private void cbxNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var name = (string)cbxNames.SelectedItem;
            txtContent.Text += name + Environment.NewLine;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //save

            //configure

            Close();
        }

        private void btnClose_Click(object sender, object e)
        {

        }
    }
}
