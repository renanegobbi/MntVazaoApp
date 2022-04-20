using MntVazaoApp.Models;
using MntVazaoApp.Util;
using MntVazaoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MntVazaoApp.Droid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeViewModel ViewModel { get; set; }
        public HomeView()
        {
            InitializeComponent();
            this.ViewModel = new HomeViewModel(); 
            this.BindingContext = this.ViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<string>(this, "FalhaBuscaPorIdSensor", 
            async (IdSensor) =>
            {
                await DisplayAlert("NÃO ENCONTRADO", $"Sensor com id = {IdSensor} não encontrado!" +
                    $"\nInsira um id válido.", "OK");
                Grafico.CriaGraficoSemDados();
            });

            MessagingCenter.Subscribe<BuscaPorMedicoes>(this, "FalhaBuscaPorMedicoes",
            (exc) => { Grafico.CriaGraficoSemDados(); });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "FalhaBuscaPorIdSensor");
            MessagingCenter.Unsubscribe<BuscaPorMedicoes>(this, "FalhaBuscaPorMedicoes");
        }
    }
}