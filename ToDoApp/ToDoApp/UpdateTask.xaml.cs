using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateTask : ContentPage
    {
        public UpdateTask()
        {
            InitializeComponent();
        }
        private void SaveTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (!String.IsNullOrEmpty(task.Name))
            {
                App.Database.SaveItem(task);
            }
            Navigation.PopAsync();
        }
        private void DeleteTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            App.Database.DeleteItem(task.Id);
            Navigation.PopAsync();
        }
        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (compl.IsChecked)
                complLabel.Text = "Выполнено!!!";
            else
                complLabel.Text = "Выполнить";
            
        }
    }
}