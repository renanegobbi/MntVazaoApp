using Microcharts;
using MntVazaoApp.Config;
using MntVazaoApp.Models;
using MntVazaoApp.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MntVazaoApp.Services
{
    public class BuscaPorMedicoesService
    {
        private DateTime diaHoje;

        public DateTime DiaHoje
        {
            get { return DateTime.Now; }
            set { diaHoje = value; }
        }

        public const int tamanhoPagina = 86400;

        public BuscaPorMedicoes buscaPorMedicoes { get; set; }

        public async Task<List<ChartEntry>> ShowCharts(BuscaPorMedicoes buscaPorMedicoes)
        {
            try
            {
                if (buscaPorMedicoes.EntradasGrafico != null)
                    buscaPorMedicoes.EntradasGrafico.Clear();

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(AppSettings.MntVazaUrl);

                    if (buscaPorMedicoes.SensorId <= 0) { return null; }

                    string url = httpClient.BaseAddress + String.Format("Medicao/listar-medicoes" +
                        "?Sensor_ID={0}&Medicao_DataInicio={1}&tamanho={2}",
                        buscaPorMedicoes.SensorId,
                        buscaPorMedicoes.Data != null ? buscaPorMedicoes.Data.ToString("yyyy-MM-dd") : DiaHoje.ToString("yyyy-MM-dd"),
                        tamanhoPagina.ToString());
                    var resultado = await httpClient.GetAsync(url);

                    if (resultado.StatusCode == HttpStatusCode.NotFound)
                    {
                        buscaPorMedicoes.EntradasGrafico = new List<ChartEntry>();
                        this.buscaPorMedicoes = buscaPorMedicoes;
                        MessagingCenter.Send<BuscaPorMedicoes>(this.buscaPorMedicoes, "FalhaBuscaPorMedicoes");
                    }

                    var counteudo = await resultado.Content.ReadAsStringAsync();

                    var medicaoPaginado = JsonConvert.DeserializeObject<MedicaoPaginado>(counteudo);

                    var agrupamentoPorHora = Service.AgruparMedicoesPorHora(medicaoPaginado, buscaPorMedicoes);

                    var listaChaveValor = Service.CriarListaChaveValor(agrupamentoPorHora);

                    Service.DesenharGrafico(listaChaveValor, buscaPorMedicoes);
                }
            }
            catch
            {
                MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro ao trazer os dados para o gráfico."),
"FalhaBuscaPorSensorId");
            }
            return buscaPorMedicoes.EntradasGrafico;
        }
    }
}

