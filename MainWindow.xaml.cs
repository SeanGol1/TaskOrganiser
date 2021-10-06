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
        public MainWindow()
        {
            InitializeComponent();
            PopulateList();

        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskList.Add(new Task(txtName.Text, Convert.ToInt32(txtPriority.Text), txtTime.Text));
            PopulateList();
        }

        private void PopulateList()
        {
            lvTask.ItemsSource = null;
            if (TaskList.Count != 0)
            {
                lvTask.ItemsSource = TaskList;
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
                    data.Add(task.Name + "," + task.Priority + "," + task.TimeScale);
                }

                string filepath = "C:/Users/seang/Desktop/IN DEV/TaskOrgraniser/SaveFile.txt";
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


            }
            catch (Exception ex)
            {
                // Info.  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }
    }

}
