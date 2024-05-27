using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskList.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taskList_tarea1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listView : ContentPage
    {
        public listView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadTaskList();
        }

        private async void loadTaskList()
        {
            var task_list = await App.context.getTaskList();
            listViewTask.ItemsSource = task_list;
        }

        private void btnCreateTask_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new createTaskList());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedItem = e.SelectedItem as taskListItems;

              
                // Deselect the item
                listViewTask.SelectedItem = null;

                // Navigate to the detail page
                await Navigation.PushAsync(new DetailsList(selectedItem));
            }
        }
    }
}