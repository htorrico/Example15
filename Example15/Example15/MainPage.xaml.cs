using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Example15
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            lvProyectos.ItemsSource =await ListarProyectos();
        }




        public async Task<List<ProyectoResponse>> ListarProyectos()
        {
            HttpClient client;
            client = new HttpClient();
            
            List<ProyectoResponse> proyectos = new List<ProyectoResponse>();
            Uri uri = new Uri("http://sitra.emape.gob.pe:8082/api/expedientes/obtener_proyectos/2020");

            //Guardando la respuesta del API
            HttpResponseMessage response= await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                //Almacenando el json
                string json = await response.Content.ReadAsStringAsync();
                proyectos = JsonConvert.DeserializeObject<List<ProyectoResponse>>(json);
            }

            return proyectos;

        }


        //public async Task<List<TodoItem>> Get()
        //{

        //    //Repositorio de mi respuesta
        //    Items = new List<TodoItem>();

        //    //Armo la url del servicio            
        //    Uri uri = new Uri(string.Format(Constants.RestUrl, "Get"));

        //    HttpResponseMessage response = await client.GetAsync(uri);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string content = await response.Content.ReadAsStringAsync();
        //        Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);

        //    }
        //    return Items;
        //}
    }
}
