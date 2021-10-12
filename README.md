# TaskOrganiser
Simple WPF program to keep track of daily tasks.

![TaskOrganiser](https://user-images.githubusercontent.com/14328800/137027400-84ecac74-5132-4166-ac57-ef9e215cfc6f.png)


# About the Project

## Purpose
This project was created to help with manage a large amount of tasks on a daily basis. 
As a team lead of a support team, I found there is a lot on my plate all the time.
I designed this app to run on a small window on my work PC, and to help me input and prioritise tasks.

## Use
### Add Task
First Text Box = Enter the Task Name [string] [required]  
Second Text Box = Enter a Priority (preferably 1-10) [int] [required]  
Third Text Box = Enter a Aprrox Time in Minutes [int] [required]  
Date Picker = Enter Due Date  

Click "Add Task" button to add Task to List.

### Task Display
Tasks are displayed in a Data Grid. 
You are able to filter the list to arrange the items based on type.
You can double tap the values in the datagrid to add/edit/delete content.
This can be used to create notes. 

### Save Tasks
Clicking the "Save File" button will take all the tasks created (from the list) and write them to the csv save file.

### Load Tasks
Clicking the "load File" button will read all lines from the save file and add them to the Task List.

# Setup
### Launching the App
The .exe file can be found in the bin folder under the following directory:
TaskOrganiser\bin\Debug\TaskOrganiser.exe

### Save File
Save file is located in the bin folder under the following directory:
TaskOrganiser\bin\SaveFile.txt


# Technologies 

* C# WPF Application 
* Xaml Used for Front End Display



