using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            List<Task> list = App.Database.GetItems().ToList();

            if (list.Count() != 0)
                anyTasks.IsVisible = false;
            else
            {
                
                anyTasks.IsVisible = true;
                anyTasks.Text = "Нет никаких задач!";
            }
            taskList.ItemsSource = list;
            base.OnAppearing();
        }
        // выбрать задание
        private async void SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            Task selectedtask = (Task)e.SelectedItem;
            UpdateTask updateTask = new UpdateTask();
            updateTask.BindingContext = selectedtask;
            await Navigation.PushAsync(updateTask);
        }
        // добавить задание
        private async void CreateTask(object sender, EventArgs e)
        {
            Task task = new Task();
            CreateTask createTask = new CreateTask();
            createTask.BindingContext = task;
            await Navigation.PushAsync(createTask);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            List<Task> completedTasks = new List<Task>();
            List<Task> plannedTasks = new List<Task>();
            List<Task> allTasks = App.Database.GetItems().ToList();

            // делаем списки выполненных и запланированных задач

            foreach (var task in allTasks)
            {
                if (task.Completed)
                    completedTasks.Add(task);
                else
                    plannedTasks.Add(task);
            }


            var imageButton = (ImageButton)sender;

            if (imageButton.ClassId == "Completed")
            {
                if (completedTasks.Count() != 0)
                    anyTasks.IsVisible = false;
                else
                {
                    anyTasks.IsVisible = true;
                    anyTasks.Text = "Нет выполненных задач";
                }
                taskList.ItemsSource = completedTasks;
            }
            else if (imageButton.ClassId == "Planned")
            {
                if (plannedTasks.Count() != 0)
                    anyTasks.IsVisible = false;
                else
                {
                    anyTasks.IsVisible = true;
                    anyTasks.Text = "Нет запланированных задач";
                }
                taskList.ItemsSource = plannedTasks;
            }
            else
            {
                if (allTasks.Count() != 0)
                    anyTasks.IsVisible = false;
                else
                {
                    anyTasks.IsVisible = true;
                    anyTasks.Text = "Нет никаких задач!";
                }
                taskList.ItemsSource = allTasks;
            }
        }
    }
}
