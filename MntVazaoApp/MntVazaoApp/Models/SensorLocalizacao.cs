using System;

namespace MntVazaoApp.Models
{
    public class SensorLocalizacao
    {
        public int Localizacao_ID { get; set; }

        public DateTime Sensor_Localizacao_DataInicOp { get; set; }

        public string Sensor_Localizacao_Descr { get; set; }

        public DateTime? Sensor_Localizacao_DataFimOp { get; set; }

        public double Sensor_Localizacao_Latitude { get; set; }

        public double Sensor_Localizacao_Longitude { get; set; }
    }
}
