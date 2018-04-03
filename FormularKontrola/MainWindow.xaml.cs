using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FluentValidation;
using FluentValidation.Results;

namespace FormularKontrola
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }
        public static readonly DependencyProperty ActiveProperty = DependencyProperty.Register("Active", typeof(bool), typeof(MainWindow), new UIPropertyMetadata(false));
        */
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelxd();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
