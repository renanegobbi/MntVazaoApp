using Microcharts;
using MntVazaoApp.Util;
using MntVazaoApp.ViewModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MntVazaoApp.Droid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DadosView : ContentPage
    {
        public DadosViewModel ViewModel { get; set; }

        public DadosView()
        {
            InitializeComponent();
            this.ViewModel = new DadosViewModel();
            this.BindingContext = this.ViewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.SensorExiste == null)
                Grafico.CriaGraficoSemDados();

            MessagingCenter.Subscribe<string>(this, "SensorExiste",
            (SensorExist) => { ViewModel.SensorExiste = SensorExist; });

            MessagingCenter.Subscribe<List<ChartEntry>>(this, "DadosGrafico",
            (DadosGrafico) =>
            {
                Grafico.CalculaMedia(this.ViewModel, DadosGrafico);
                Grafico.CriaGraficoBarra(Chart1, DadosGrafico);
            });
        }
    }
}