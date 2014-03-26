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

namespace gui
{
    /// <summary>
    /// Interaction logic for MoreWindow.xaml
    /// </summary>
    public partial class MoreWindow : Window
    {
        public MoreWindow()
        {
            InitializeComponent();
        }
        bool flipped = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sPanel.Orientation == Orientation.Horizontal)
            {
                sPanel.Orientation = Orientation.Vertical;
            }
            else
            {
                sPanel.Orientation = Orientation.Horizontal;
            }
            if (!flipped)
            {
                flipped = true;
                foreach (var w in Application.Current.Windows)
                {
                    if (w.GetType() == typeof(MainWindow))
                    {
                        (w as MainWindow).Progress.Value += 20;
                    }
                }
            }
            
        }
    }
}
