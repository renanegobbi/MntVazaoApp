using Microcharts;
using System;
using System.Collections.Generic;

namespace MntVazaoApp.Models
{
    public class BuscaPorMedicoes
    {
        public int SensorId { get; set;}
        public List<ChartEntry> EntradasGrafico { get; set; }
        public DateTime Data { get; set;}

        public BuscaPorMedicoes(int SensorId, List<ChartEntry> EntradasGrafico)
        {
            this.SensorId = SensorId;
            this.EntradasGrafico = EntradasGrafico;
        }

        public BuscaPorMedicoes(int SensorId, List<ChartEntry> EntradasGrafico, DateTime Data)
        {
            this.SensorId = SensorId;
            this.EntradasGrafico = EntradasGrafico;
            this.Data = Data;
        }
    }
}
