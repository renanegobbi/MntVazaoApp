using Microcharts;
using MntVazaoApp.Models;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;

namespace MntVazaoApp.Util
{
    public static class Service
    {
        public static IOrderedEnumerable<IGrouping<int, Medicao>> AgruparMedicoesPorHora(MedicaoPaginado medicaoPaginado, BuscaPorMedicoes buscaPorMedicoes)
        {
            var agrupamentoPorHora = from medicao in medicaoPaginado.Resultado
                                     where medicao.Medicao_DataInicio.Date.ToString() == buscaPorMedicoes.Data.Date.ToString()
                                     group medicao by medicao.Medicao_DataInicio.Hour into newGroup
                                     orderby newGroup.Key
                                     select newGroup;

            return agrupamentoPorHora;
        }

        public static List<KeyValuePair<int, float>> CriarListaChaveValor(IOrderedEnumerable<IGrouping<int, Medicao>> agrupamentosPorHora)
        {
            var listaChaveValor = new List<KeyValuePair<int, float>>();

            foreach (var agrupamentoPorHora in agrupamentosPorHora)
                listaChaveValor.Add(new KeyValuePair<int, float>(agrupamentoPorHora.Key, agrupamentoPorHora.Average(m => m.Medicao_Leitura)));

            return listaChaveValor;
        }

        public static void DesenharGrafico(List<KeyValuePair<int, float>> listaChaveValor, BuscaPorMedicoes buscaPorMedicoes)
        {
            for (int hora = 0; hora <= 23; hora++)
            {
                buscaPorMedicoes.EntradasGrafico.Add(new ChartEntry(listaChaveValor[hora].Value)
                {
                    Color = SKColor.Parse("#2196f3"),
                    Label = listaChaveValor[hora].Key.ToString(), //Label do eixo x
                    ValueLabel = listaChaveValor[hora].Value.ToString("F"), //Label do eixo y
                });
            }
        }
    }
}
