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
using BussinessManager;

namespace ProductRevisionAppWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int validUserID = LoginManager.Login(TextName.Text, TextSurname.Text, TextPassword.Password);
                RedirectToNewWindowWithUserID(validUserID);
            }
            catch (ArgumentException er)
            {
                MessageBox.Show(er.Message);
            }
            
            
        }

        private void RedirectToNewWindowWithUserID(int validUserID)
        {
            MainWindow mainWindow = new MainWindow(validUserID);
            mainWindow.Show();
            this.Close();
        }
    }
}
