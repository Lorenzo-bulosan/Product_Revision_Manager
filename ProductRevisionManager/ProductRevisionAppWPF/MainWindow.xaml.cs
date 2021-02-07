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
using BussinessManager;

namespace ProductRevisionAppWPF
{

    public partial class MainWindow : Window
    {

        private BussinessMain _instance;

        public MainWindow()
        {
            _instance = new BussinessMain();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabelTest.Content = _instance.TestString();
            LabelName.Content = _instance.RetrieveAll();
            ListBoxTasks.ItemsSource = _instance.RetrieveAll();
        }
        
        private void ListBox_TaskSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
