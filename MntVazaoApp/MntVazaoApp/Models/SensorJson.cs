using System;

namespace MntVazaoApp.Models
{
    public class SensorJson
    {
        public int Sensor_ID { get; set; }
        public string Sensor_Descricao { get; set; }
        public string Sensor_Ativo { get; set; } // Sensor ativo no momento? (0=Não, 1=Sim)
        public string Sensor_Modelo { get; set; }
        public double Sensor_PressaoNominal { get; set; }
        public string Sensor_PressaoUnidade { get; set; }
        public double Sensor_VazaoMin { get; set; }
        public double Sensor_VazaoMax { get; set; }
        public string Sensor_VazaoUnidade { get; set; }
        public string Sensor_CodigoUPC { get; set; }
        public string Sensor_Fabricante { get; set; }
        public string Sensor_FabricantePartNumber { get; set; }
        public DateTime? Sensor_DataInicOp { get; set; }
        public DateTime? Sensor_DataFimOp { get; set; }
        public string Organizacao_Nome { get; set; }
        public string Organizacao_Telefone { get; set; }
        public string Organizacao_Email { get; set; }
        public string Organizacao_Endereco { get; set; }
        public string Localizacao_Descricao { get; set; }
        public string Localizacao_Latitude { get; set; }
        public string Localizacao_Longitude { get; set; }
        public string Localizacao_Sensor { get; set; }
    }
}

