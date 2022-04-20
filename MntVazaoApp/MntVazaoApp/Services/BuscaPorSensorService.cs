using MntVazao.App.Models;
using MntVazaoApp.Config;
using MntVazaoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MntVazaoApp.Services
{
    public class BuscaPorSensorService
    {
        public async Task<ObservableCollection<SensorJson>> ObterSensorPorIdAsync(BuscaPorSensor buscaPorSensor)
        {
            try
            {
                buscaPorSensor.Sensor.Clear();
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(AppSettings.MntVazaUrl);

                    if (buscaPorSensor.IdSensor <= 0) { return null; }

                    var response = await httpClient.GetAsync($"Sensor/sensor-obter?sensor_id={buscaPorSensor.IdSensor}");
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        buscaPorSensor.Sensor = new ObservableCollection<SensorJson>();
                        MessagingCenter.Send<string>(buscaPorSensor.IdSensor.ToString(), "FalhaBuscaPorIdSensor");
                        MessagingCenter.Send<string>("false", "SensorExiste");
                    }
                    else
                    {
                        var resultado = await response.Content.ReadAsStringAsync();
                        var sensor = JsonConvert.DeserializeObject<Sensor>(resultado);
                        MessagingCenter.Send<string>("true", "SensorExiste");

                        buscaPorSensor.Sensor.Add(new SensorJson
                        {
                            Sensor_ID = sensor.Sensor_ID,
                            Sensor_Descricao = sensor.Sensor_Descricao,
                            Sensor_Ativo = (sensor.Sensor_Ativo.ToString() == "true") ? "Sim" : "Não",
                            Sensor_Modelo = sensor.Sensor_Modelo,
                            Sensor_PressaoNominal = sensor.Sensor_PressaoNominal.Value,
                            Sensor_PressaoUnidade = sensor.Sensor_PressaoUnidade,
                            Sensor_VazaoMin = sensor.Sensor_VazaoMin.Value,
                            Sensor_VazaoMax = sensor.Sensor_VazaoMax.Value,
                            Sensor_VazaoUnidade = sensor.Sensor_VazaoUnidade,
                            Sensor_CodigoUPC = sensor.Sensor_CodigoUPC,
                            Sensor_Fabricante = sensor.Sensor_Fabricante,
                            Sensor_FabricantePartNumber = sensor.Sensor_FabricantePartNumber,
                            Sensor_DataInicOp = sensor.Sensor_DataInicOp,
                            Organizacao_Telefone = sensor.Organizacao.Organizacao_Tel,
                            Sensor_DataFimOp = sensor.Sensor_DataFimOp,
                            Organizacao_Nome = sensor.Organizacao.Organizacao_Nome,
                            Organizacao_Email = sensor.Organizacao.Organizacao_Email,
                            Organizacao_Endereco = sensor.Organizacao.Organizacao_Endereco,
                            Localizacao_Descricao = sensor.SensorLocalizacao.Last().Sensor_Localizacao_Descr,
                            Localizacao_Latitude = sensor.SensorLocalizacao.Last().Sensor_Localizacao_Latitude.ToString(),
                            Localizacao_Longitude = sensor.SensorLocalizacao.Last().Sensor_Localizacao_Longitude.ToString(),
                        });
                    }
                }
            }

            catch
            {
                MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
Por favor verifique a sua conexão e tente novamente mais tarde."),
"FalhaBuscaPorSensorId");
            }

            return buscaPorSensor.Sensor;
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message) { }
    }
}
