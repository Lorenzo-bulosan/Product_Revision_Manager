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
using Microsoft.EntityFrameworkCore;

namespace ProductRevisionAppWPF
{

    public partial class MainWindow : Window
    {
        // testing in development: "logged in user"
        private int _userId = 1; //13, 14, 15
        private string _firstName = "Lorenzo";
        private string _lastName = "Bulosan";
        private int _projectID;
        private string _projectName;
        private int _selectedRevision = 0;
        private string _revisionDeadline;
        private int _urgencyForNewTask = 1;
        //

        private Dictionary<int, string> _urgencyDict = new Dictionary<int, string>()
        {
            [1] = "Low",
            [2] = "Medium",
            [3] = "High",
            [4] = "Urgent"
        };

        private Dictionary<int, string> _progressDict = new Dictionary<int, string>()
        {
            [0] = "No Progress",
            [1] = "In Progress ",
            [2] = "In Testing ",
            [3] = "Completed"
        };

        private RevisionManager _instance;

        public MainWindow(int userID)
        {
            InitializeComponent();

            _instance = new RevisionManager();

            _userId = userID;

            // populate information
            SetCurrentUserInformation();
            PopulateProjectInfo();
            GetRevisionsFromProjectID(_projectID);
            GetAllTasksFromRevisionAndPopulate();
            PopulateComboBoxUrgency();
            PopulateComboBoxProgress();
            PopulateProjectsDependOnUser();
        }

        private void SetCurrentUserInformation()
        {
            // retrieving user object but using linq to only extract needed information
            // for the future if needed to extract more it is left as whole object
            _firstName = _instance.GetUserInformationFromUserID(_userId).firstName;
            _lastName = _instance.GetUserInformationFromUserID(_userId).lastName;
        }

        private void PopulateProjectInfo()
        {
            LabelUserName.Content = $"{_firstName} {_lastName}";
            LabelProjectSelected.Content = $"Project: {_projectName}";
            LabelRevisionSelected.Content = $"Revision: {_revisionDeadline}";
        }

        private void GetAllTasksFromRevisionAndPopulate()
        {
            ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
        }

        private void GetRevisionsFromProjectID(int projectId)
        {
            var revisions = _instance.GetRevisionsFromProject(projectId);
            
            // populate revision combobox
            ComboBoxRevisions.ItemsSource = revisions;
        }
        
        private void ListBox_TaskSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _instance.SetSelectedRevisionTask(ListBoxTasks.SelectedItem); 
            PopulateMainScreenWithCurrentTaskSelected();
            RetrieveCommentsForTask();            
        }

        private void PopulateMainScreenWithCurrentTaskSelected()
        {
            var selectectTask = _instance.SelectedRevisionTask;

            if (selectectTask != null)
            {
                TextCurrentTaskTitle.Text = selectectTask.title;
                TextCurrentTaskURL.Text = selectectTask.links;
                TextCurrentTaskDescription.Text = selectectTask.description;
                int urgency = _instance.SelectedRevisionTask.urgency;
                int progress = _instance.SelectedRevisionTask.progress;                
                ComboBoxCurrentTaskUrgency.SelectedIndex = urgency;
                ComboBoxCurrentTaskProgress.SelectedIndex = progress;
                
            }
            else
            {
                // Default values when refreshed
                TextCurrentTaskTitle.Text = "Select a revision from the dropdown!";
                TextCurrentTaskDescription.Text = "Select a task from the list";
                TextCurrentTaskURL.Text = "Check me out at: https://github.com/Lorenzo-bulosan";
                //ComboBoxCurrentTaskUrgency.SelectedValue = 1;

            }
        }

        private void ComboBoxRevisions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxRevisions.SelectedItem != null)
            {
                KeyValuePair<int, DateTime> _selectedRevisionInfo = (KeyValuePair<int, DateTime>)ComboBoxRevisions.SelectedItem;
                _selectedRevision = _selectedRevisionInfo.Key;
                _revisionDeadline = _selectedRevisionInfo.Value.ToString();
 
                GetRevisionsFromProjectID(_projectID);
                ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
                PopulateProjectInfo();
            }
            
        }

        private void ButtonAddTask_Click(object sender, RoutedEventArgs e)
        {
            // add 
            if (_selectedRevision != 0)
            {
                _instance.AddTaskToRevision(_selectedRevision, TextBoxTitle.Text, TextBoxDescription.Text, _urgencyForNewTask);

                // refresh
                ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
            }
            

        }

        private void ComboBoxUrgency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _urgencyForNewTask = (int)ComboBoxUrgency.SelectedValue;            
        }

        private void PopulateComboBoxUrgency()
        {
            // bind to combobox
            ComboBoxUrgency.ItemsSource = _urgencyDict;
            ComboBoxCurrentTaskUrgency.ItemsSource = _urgencyDict;
        }

        private void PopulateComboBoxProgress()
        {
            ComboBoxCurrentTaskProgress.ItemsSource = _progressDict;
        }

        private void UpdateRevisionTask(object sender, RoutedEventArgs e)
        {
            if (_instance.SelectedRevisionTask != null)
            {
                // update
                _instance.UpdateRevisionTask(_instance.SelectedRevisionTask.TaskID, TextCurrentTaskTitle.Text, TextCurrentTaskDescription.Text, ComboBoxCurrentTaskUrgency.SelectedIndex, ComboBoxCurrentTaskProgress.SelectedIndex, TextCurrentTaskURL.Text);

                // refresh
                PopulateMainScreenWithCurrentTaskSelected();
                ListBoxTasks.ItemsSource = _instance.GetTasksFromRevisionID(_selectedRevision);
            }
        }

        private void RetrieveCommentsForTask()
        {
            var selectectTask = _instance.SelectedRevisionTask;

            if (selectectTask!=null)
            {
                //ListViewComments.ItemsSource = _instance.RetrieveCommentsFromTaskID(_instance.SelectedRevisionTask.TaskID);
                ListViewComments.ItemsSource = _instance.RetrieveCommentsOfTaskFromUser(_userId, selectectTask.TaskID);
            }
            else
            {
                ListViewComments.ItemsSource = null;
            }

        }

        private void ButtonSendComment_Click(object sender, RoutedEventArgs e)
        {
            var selectectTask = _instance.SelectedRevisionTask;

            if (selectectTask != null && TextBoxCommentInput.Text!="")
            {
                _instance.AddCommentToTaskID(selectectTask.TaskID, TextBoxCommentInput.Text, $"{_firstName} {_lastName}");
                RetrieveCommentsForTask();
            }
        }

        private void ComboBoxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // get key value pair back when selected
            KeyValuePair<int, string> projectIdAndValue = (KeyValuePair<int, string>)ComboBoxProjects.SelectedItem;

            // set corresponding information 
            _projectName = projectIdAndValue.Value;
            _projectID = projectIdAndValue.Key;
            GetRevisionsFromProjectID(_projectID);

            // refresh
            PopulateProjectInfo();
        }

        private void PopulateProjectsDependOnUser()
        {
            ComboBoxProjects.ItemsSource = _instance.GetProjectsFromUserID(_userId);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void ButtonAddRevision_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
