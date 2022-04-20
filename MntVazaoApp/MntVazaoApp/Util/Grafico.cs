using Microcharts;
using Microcharts.Forms;
using MntVazaoApp.ViewModel;
using SkiaSharp;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;

namespace MntVazaoApp.Util
{
    public static class Grafico
    {
        public static void CriaGraficoSemDados()
        {
            List<ChartEntry> EntradasGrafico = new List<ChartEntry>();
            for (int i = 0; i < 24; i++)
            {
                EntradasGrafico.Add(new ChartEntry(0)
                {
                    Color = SKColor.Parse("#2196f3"),
                    Label = (i).ToString(), //Label do eixo x
                    ValueLabel = 0.ToString(), //Label do eixo y
                });
            }
            MessagingCenter.Send(EntradasGrafico, "DadosGrafico");
        }

        public static void CalculaMedia(DadosViewModel ViewModel, List<Entry> EntradasGrafico)
        {
            float MediaDia = 0;

            foreach (var EntradaGrafico in EntradasGrafico)
            {
                MediaDia = MediaDia + float.Parse(EntradaGrafico.ValueLabel);
            }

            ViewModel.MediaDiaFormatado = (MediaDia == 0)
                                            ? ("0")
                                            : (MediaDia / 24).ToString("F3", new CultureInfo("pt-BR"));
        }

        public static void CriaGraficoBarra(ChartView Grafico, List<Entry> EntradasGrafico)
        {
            Grafico.Chart = new BarChart
            {
                Entries = EntradasGrafico,
            };
        }
    }
}
