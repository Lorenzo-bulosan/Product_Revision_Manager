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
        // testing in development
        private string _firstName = "Lorenzo";
        private string _lastName = "Bulosan";
        private string _project = "project2";
        private int _selectedRevision = 3;
        //

        private RevisionManager _instance;

        public MainWindow()
        {
            _instance = new RevisionManager();
            InitializeComponent();

            // log in here

            SetCurrentUserInformation();
            GetRevisionsFromProject(_project);
            ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
        }

        private void SetCurrentUserInformation()
        {
            LabelUserName.Content = $"{_firstName} {_lastName}";
            LabelProjectSelected.Content = $"Project: {_project}";
            LabelRevisionSelected.Content = $"Revision: {_selectedRevision}";
        }

        private void GetRevisionsFromProject(string uniqueProjectName)
        {
            ComboBoxRevisions.ItemsSource = _instance.GetRevisionsFromProject(uniqueProjectName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabelTest.Content = _instance.TestString();

        }
        
        private void ListBox_TaskSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxRevisions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedRevision = (int)ComboBoxRevisions.SelectedItem;
            SetCurrentUserInformation();
            GetRevisionsFromProject(_project);
            ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
        }

        private void ButtonAddTask_Click(object sender, RoutedEventArgs e)
        {
            // add 
            _instance.AddTaskToRevision(_selectedRevision, TextBoxTitle.Text, TextBoxDescription.Text, 3);

            // refresh
            ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);

        }
    }
}
