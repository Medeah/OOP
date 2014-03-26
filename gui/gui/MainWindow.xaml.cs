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

namespace gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool morevist = false;
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!morevist)
            {
                morevist = true;
                Progress.Value += 20;          
            }

            var win = new MoreWindow();

            win.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Progress.Value += 20;
            drop.SelectionChanged -= check_Checked;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked.Value)
            {
                Application.Current.Shutdown();
            }
            System.Windows.MessageBox.Show("You need to say yes", "war", System.Windows.MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            Progress.Value += 20;
            check.Checked -= check_Checked;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tek.Text == "yes")
            {
                Progress.Value += 20;
            }
        }
    }
}