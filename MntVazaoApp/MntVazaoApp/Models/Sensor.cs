﻿using MntVazaoApp.Models;
using System;
using System.Collections.Generic;

namespace MntVazao.App.Models
{
    public class Sensor
    {
        public int Sensor_ID { get; set; }

        public string Sensor_Descricao { get; set; }

        public bool Sensor_Ativo { get; set; }

        public string Sensor_Modelo { get; set; }

        public double? Sensor_PressaoNominal { get; set; }

        public string Sensor_PressaoUnidade { get; set; }

        public double? Sensor_VazaoMin { get; set; }

        public double? Sensor_VazaoMax { get; set; }

        public string Sensor_VazaoUnidade { get; set; }

        public string Sensor_CodigoUPC { get; set; }

        public string Sensor_Fabricante { get; set; }

        public string Sensor_FabricantePartNumber { get; set; }

        public DateTime? Sensor_DataInicOp { get; set; }

        public DateTime? Sensor_DataFimOp { get; set; }

        public Organizacao Organizacao { get; set; }

        public IEnumerable<SensorLocalizacao> SensorLocalizacao { get; set; }
    }
}


