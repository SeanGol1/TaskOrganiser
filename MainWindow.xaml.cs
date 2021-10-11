using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace TaskOrgraniser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Task> TaskList = new List<Task>();
        public List<Task> tempTaskList = new List<Task>();
        public MainWindow()
        {
            InitializeComponent();
            PopulateList(true);

        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskList.Add(new Task(txtName.Text, Convert.ToInt32(txtPriority.Text), Convert.ToInt32(txtTime.Text), ""));
            PopulateList(true);
        }

        private void PopulateList(bool full)
        {
            dgridTask.ItemsSource = null;
            if (full == true)
            {
                if (TaskList.Count != 0)
                {
                    dgridTask.ItemsSource = TaskList;
                }
            }
            else
            {
                if (tempTaskList.Count != 0)
                {
                    dgridTask.ItemsSource = tempTaskList;
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verification.  
                if (TaskList.Count <= 0)
                {
                    // Message.  
                    MessageBox.Show("There is no data available to export.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    // Info.  
                    return;
                }

                List<string> data = new List<string>();

                foreach (Task task in TaskList)
                {
                    data.Add(task.Name + "," + task.Priority + "," + task.TimeScale + "," + task.Notes);
                }

                string filepath = "../SaveFile.txt";
                File.WriteAllLines(filepath, data);

                // Info.  
                MessageBox.Show("Data has been sucessfully exported to CSV file", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }


        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int counter = 0;
                string line;
                TaskList.Clear();
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"../SaveFile.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] items = line.Split(',');
                    TaskList.Add(new Task(items[0], Convert.ToInt32(items[1]), Convert.ToInt32(items[2]), items[3]));
                    counter++;
                }

                PopulateList(true);
                file.Close();


            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

       

        private void CbxHPriority_Checked(object sender, RoutedEventArgs e)
        {

            if (cbxQuick.IsChecked == true)
            {
                List<Task> newtemp = new List<Task>(tempTaskList);                 
                tempTaskList.Clear();
                foreach (Task item in newtemp)
                {
                    if (item.Priority > 7)
                    {
                        tempTaskList.Add(item);
                    }
                }
            }
            else
            {
                foreach (Task item in TaskList)
                {
                    if (item.Priority > 7)
                    {
                        tempTaskList.Add(item);
                    }
                }
            }
            PopulateList(false);
        }

        private void CbxQuick_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxHPriority.IsChecked == true)
            {
                List<Task> newtemp = new List<Task>(tempTaskList);
                tempTaskList.Clear();
                foreach (Task item in newtemp)
                {
                    if (item.TimeScale <= 15)
                    {
                        tempTaskList.Add(item);
                    }
                }
            }
            else
            {
                foreach (Task item in TaskList)
                {
                    if (item.TimeScale <= 15)
                    {
                        tempTaskList.Add(item);
                    }
                }
            }
            PopulateList(false);
        }

        private void CbxQuick_Unchecked(object sender, RoutedEventArgs e)
        {
            tempTaskList.Clear();
            PopulateList(true);
        }
    }

}
