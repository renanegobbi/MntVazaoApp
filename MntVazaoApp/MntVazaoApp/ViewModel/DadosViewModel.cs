using Microcharts;
using MntVazaoApp.Models;
using MntVazaoApp.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MntVazaoApp.ViewModel
{
    public class DadosViewModel : BaseViewModel
    {
        public ICommand BuscarPorDataCommand { get; set; }

        public List<ChartEntry> EntradasGrafico { get; set; }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        private string mediaDiaFormatado;

        public string MediaDiaFormatado
        {
            get { return mediaDiaFormatado + " L/H"; }
            set { 
                mediaDiaFormatado = value;
                OnPropertyChanged();
            }
        }

        private string idSensor;
        public string IdSensor
        {
            get { return idSensor; }
            set { idSensor = value; }
        }

        DateTime dataLeituraMedicao = DateTime.Today;
        public DateTime DataLeituraMedicao
        {
            get { return dataLeituraMedicao; }
            set { 
                dataLeituraMedicao = value;
            }
        }

        private string sensorExiste;
        public string SensorExiste
        {
            get { return sensorExiste; }
            set
            {
                sensorExiste = value;
                ((Command)BuscarPorDataCommand).ChangeCanExecute();
            }
        }

        public DadosViewModel()
        {
            this.EntradasGrafico = new List<ChartEntry>();

            MessagingCenter.Subscribe<string>(this, "IdSensor",
                (IdSensor) => { this.IdSensor = IdSensor; });

            BuscarPorDataCommand = new Command(async () =>
            {
                var buscaPorMedicoesService = new BuscaPorMedicoesService();
                this.Aguarde = true;

                if (idSensor != null)
                {
                    await buscaPorMedicoesService.ShowCharts(
                        new BuscaPorMedicoes(int.Parse(idSensor), EntradasGrafico, this.dataLeituraMedicao));

                    if (EntradasGrafico != null && EntradasGrafico.Count == 0)
                        MessagingCenter.Send(EntradasGrafico, "DadosGraficoInexistentes");

                    if (EntradasGrafico != null && EntradasGrafico.Count != 0)
                        MessagingCenter.Send(EntradasGrafico, "DadosGrafico");
                }

                this.Aguarde = false;
            }, () =>
            {
                return sensorExiste == "true"; // habilita o botão "Buscar" para essa condição
            });
        }
    }
}
