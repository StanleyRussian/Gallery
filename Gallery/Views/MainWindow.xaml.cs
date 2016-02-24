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

namespace Gallery
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

        private GridLength expandedHeight = new GridLength(0.5, GridUnitType.Star);

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            expanderRow.Height = expandedHeight;
            expander.Visibility = Visibility.Visible;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            expandedHeight = expanderRow.Height;
            expanderRow.Height = GridLength.Auto;
            expander.Visibility = Visibility.Collapsed;
        }
    }
}
