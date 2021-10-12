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
        
        public static List<Task> TaskList = new List<Task>();
        public List<Task> tempTaskList;
        public MainWindow()
        {            
            InitializeComponent();
            PopulateList();
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            //Add Task to list   
            TaskList.Add(new Task(txtName.Text, Convert.ToInt32(txtPriority.Text), Convert.ToInt32(txtTime.Text), Convert.ToDateTime(datepicker.SelectedDate)));
            PopulateList();
        }

        private void PopulateList()
        {
            //Clear the Datagrid
            dgridTask.ItemsSource = null;

            //Filter down the list based on the checkbox's
            FilterCheck();

            //Set temp list as display list
            if (tempTaskList.Count != 0)
            {
                dgridTask.ItemsSource = tempTaskList;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if (TaskList.Count <= 0)
                { 
                    MessageBox.Show("There is no data available to export.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);  
                    return;
                }

                List<string> data = new List<string>();
                foreach (Task task in TaskList)
                {
                    data.Add(task.Name + "," + task.Priority + "," + task.TimeScale + "," + task.Notes + "," + task.DueDate);
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
                // Read the file 
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"../SaveFile.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] items = line.Split(',');

                    //Create Task using ... Name , Priority , TimeScale , Notes , DueDate
                    TaskList.Add(new Task(items[0], Convert.ToInt32(items[1]), Convert.ToInt32(items[2]), items[3], Convert.ToDateTime(items[4])));
                    counter++;
                }

                PopulateList();
                file.Close();
            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);             
            }
        }

        private void Cbx_Changed(object sender, RoutedEventArgs e)
        { 
            PopulateList();
        }

        //Checkbox / Filter Logic goes here
        private void FilterCheck()
        {
            //Temp list used to control the display items.
            tempTaskList = new List<Task>(TaskList);

            //If 15 min checkbox is ticket, remove other items from the list.
            if (cbxQuick.IsChecked == true)
            {
                List<Task> newtemp = new List<Task>(tempTaskList);
                foreach (Task item in newtemp)
                {
                    if (item.TimeScale > 15)
                    {
                        tempTaskList.Remove(item);
                    }
                }
            }

            //If High Priority checkbox is ticket, remove items under 8 from the list.
            if (cbxHPriority.IsChecked == true)
            {
                List<Task> newtemp = new List<Task>(tempTaskList);
                foreach (Task item in newtemp)
                {
                    if (item.Priority < 8)
                    {
                        tempTaskList.Remove(item);
                    }
                }
            }            
        }
    }
}
