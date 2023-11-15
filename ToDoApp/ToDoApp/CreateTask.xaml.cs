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
    public partial class CreateTask : ContentPage
    {
        public CreateTask()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            string result = enterDate.Date.ToString().Replace("12:00:00 AM", enterTime.Time.ToString());

            Task task = new Task
            {
                Name = enterName.Text,
                Date_Time = Convert.ToDateTime(result),
                Status = "Planned",
                Decription = enterDesc.Text,
                Completed = false
            };

            App.Database.SaveItem(task);
            enterName.Text = "";
            enterDesc.Text = "";
        }
    }
}