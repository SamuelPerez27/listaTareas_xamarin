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
    public partial class DetailsList : ContentPage
    {
        public DetailsList(taskListItems item)
        {
            InitializeComponent();
            BindingContext = item;
        }

        private void btn_regresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmacion", "¿Estas seguro que deseas eliminar la tarea?", "Si", "NO"))
            {
                var item = BindingContext as taskListItems;
                var deletedResult = App.context.deleteTaskList(item);
                if (await deletedResult == 1)
                {
                    await DisplayAlert("Informativo", "Se a eliminado el tarea", "Aceptar");
                    await Navigation.PopAsync();
                }
            }
        }

        private async void btn_editTask_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txt_taskName.Text))
                {
                    await DisplayAlert("Error", "Debes ingresar el nombre de la tarea", "Aceptar");

                }

                if (string.IsNullOrEmpty(txt_taskDescription.Text))
                {
                    await DisplayAlert("Error", "Debes ingresar la descripcion de la tarea", "Aceptar");
                }

                if (!string.IsNullOrEmpty(txt_taskName.Text) && !string.IsNullOrEmpty(txt_taskDescription.Text))
                {

                   
                    var item = BindingContext as taskListItems;
                    var result = App.context.editItem(item);

                    if (await result == 1)
                    {

                        await DisplayAlert("Registro guardado", "Se guardo el registro de forma satisfactoria", "Aceptar");
                        txt_taskDescription.Text = "";
                        txt_taskName.Text = "";
                        await Navigation.PopAsync();

                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo guardar la tarea por un error inesperado", "Aceptar");
                    }

                }



            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}