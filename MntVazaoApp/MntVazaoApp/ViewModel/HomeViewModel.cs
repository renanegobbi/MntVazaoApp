using Microcharts;
using MntVazaoApp.Models;
using MntVazaoApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MntVazaoApp.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<SensorJson> Sensor { get; set; }
        public ICommand BuscarSensorCommand { get; private set; }

        public int idSensor;
        public int IdSensor
        {
            get { return idSensor; }
            set
            {
                idSensor = value;
                if (value != 0)
                    MessagingCenter.Send(idSensor.ToString(), "IdSensor");

                OnPropertyChanged();
                ((Command)BuscarSensorCommand).ChangeCanExecute();
            }
        }

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

        private bool sensorExiste;
        public bool SensorExiste
        {
            get { return sensorExiste; }
            set
            {
                sensorExiste = value;
                OnPropertyChanged();
            }
        }

        DateTime dataLeituraMedicao = DateTime.Today;
        public DateTime DataLeituraMedicao
        {
            get { return dataLeituraMedicao; }
            set { dataLeituraMedicao = value; }
        }

        public List<ChartEntry> EntradasGrafico { get; set; }

        public HomeViewModel()
        {
            this.sensorExiste = false;
            this.Sensor = new ObservableCollection<SensorJson>();
            this.EntradasGrafico = new List<ChartEntry>();

            BuscarSensorCommand = new Command(async () =>
            {
                var buscaSensorService = new BuscaPorSensorService();
                var buscaMedicoesService = new BuscaPorMedicoesService();
                this.Aguarde = true;
                await buscaSensorService.ObterSensorPorIdAsync(new BuscaPorSensor(idSensor, Sensor));

                if (Sensor.Count != 0) // se encontrar algum sensor
                {
                    this.SensorExiste = true;

                    await buscaMedicoesService.ShowCharts(new BuscaPorMedicoes(idSensor, EntradasGrafico));

                    MessagingCenter.Send<ObservableCollection<SensorJson>>(Sensor, "CriarMapa");

                    if (this.EntradasGrafico.Count == 0)
                        MessagingCenter.Send(EntradasGrafico, "DadosGraficoInexistentes");
                }
                else
                {
                    var sensorInexistente = new ObservableCollection<SensorJson>() 
                    { new SensorJson { Localizacao_Latitude = null, Localizacao_Longitude = null} };
                    MessagingCenter.Send<ObservableCollection<SensorJson>>(sensorInexistente, "CriarMapa");
                }

                if (EntradasGrafico != null)
                {
                    MessagingCenter.Send(EntradasGrafico, "EntradasGrafico");
                }
                this.Aguarde = false;
            }, () =>
            {
                return idSensor > 0; // habilita o botão "Buscar" para essa condição
            });
        }
    }
}


