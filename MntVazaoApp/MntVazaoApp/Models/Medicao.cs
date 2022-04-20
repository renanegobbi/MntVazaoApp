using System;
using System.Collections.Generic;

namespace MntVazaoApp.Models
{
    public class Medicao
    {
        public int Sensor_ID { get; set; }
        public DateTime Medicao_DataInicio { get; set; }
        public DateTime Medicao_DataFim { get; set; }
        public float Medicao_Leitura { get; set; }
        public bool Medicao_Status { get; set; }
    }

    public class MedicaoPaginado
    {
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int NumeroPagina { get; set; }
        public List<Medicao> Resultado { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }
}
