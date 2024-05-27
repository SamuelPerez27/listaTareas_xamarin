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
    public partial class createTaskList : ContentPage
    {
        public createTaskList()
        {
            InitializeComponent();
        }

        private void btn_regresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btn_addTask_Clicked(object sender, EventArgs e)
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

                    var item = new taskListItems
                    {
                        name = txt_taskName.Text,
                        description = txt_taskDescription.Text,
                    };

                    var result = App.context.insertItem(item);

                    if(await result == 1) {

                        await DisplayAlert("Registro guardado", "Se guardo el registro de forma satisfactoria", "Aceptar");
                        txt_taskDescription.Text = "";
                        txt_taskName.Text = "";
                        Navigation.PopAsync();

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