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
        private int _selectedUrgency = 1;
        //

        private RevisionManager _instance;

        public MainWindow()
        {
            _instance = new RevisionManager();
            InitializeComponent();

            // log in here

            SetCurrentUserInformation();
            GetRevisionsFromProject(_project);
            GetAllTasksFromRevisionAndPopulate();

            PopulateComboboxUrgency();

        }

        private void SetCurrentUserInformation()
        {
            LabelUserName.Content = $"{_firstName} {_lastName}";
            LabelProjectSelected.Content = $"Project: {_project}";
            LabelRevisionSelected.Content = $"Revision: {_selectedRevision}";
        }

        private void GetAllTasksFromRevisionAndPopulate()
        {
            ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
        }

        private void GetRevisionsFromProject(string uniqueProjectName)
        {
            var revisions = _instance.GetRevisionsFromProject(uniqueProjectName);
            
            // populate revision combobox
            ComboBoxRevisions.ItemsSource = revisions;
        }
        
        private void ListBox_TaskSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _instance.SetSelectedRevisionTask(ListBoxTasks.SelectedItem); 
            PopulateMainScreenWithCurrentTaskSelected();
        }

        private void PopulateMainScreenWithCurrentTaskSelected()
        {
            if (_instance.SelectedRevisionTask != null)
            {
                TextCurrentTaskTitle.Text = _instance.SelectedRevisionTask.title;
                LabelCurrentTaskUrgency.Content = _instance.SelectedRevisionTask.urgency.ToString();
                TextCurrentTaskURL.Text = _instance.SelectedRevisionTask.links;
                TextCurrentTaskDescription.Text = _instance.SelectedRevisionTask.description;
            }
            else
            {
                TextCurrentTaskTitle.Text = "No title";
                LabelCurrentTaskUrgency.Content = "No urgency";
                TextCurrentTaskURL.Text = "URL";
                TextCurrentTaskDescription.Text = "No description";
            }
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
            _instance.AddTaskToRevision(_selectedRevision, TextBoxTitle.Text, TextBoxDescription.Text, _selectedUrgency);

            // refresh
            ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);

        }

        private void ComboBoxUrgency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUrgency = (int)ComboBoxUrgency.SelectedValue;
        }

        private void PopulateComboboxUrgency()
        {
            Dictionary<int, string> urgencyDict = new Dictionary<int, string>();
            urgencyDict.Add(1,"Low");
            urgencyDict.Add(2,"Medium");
            urgencyDict.Add(3,"High");
            urgencyDict.Add(4,"Urgent");

            // bind to combobox
            ComboBoxUrgency.ItemsSource = urgencyDict;
        }

    }
}
