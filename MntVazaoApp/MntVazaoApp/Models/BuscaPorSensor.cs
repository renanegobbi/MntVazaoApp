using System.Collections.ObjectModel;

namespace MntVazaoApp.Models
{
    public class BuscaPorSensor
    {
        public int IdSensor { get; set; }
        public ObservableCollection<SensorJson> Sensor { get; set; }

        public BuscaPorSensor(int IdSensor, ObservableCollection<SensorJson> Sensor)
        {
            this.IdSensor = IdSensor;
            this.Sensor = Sensor;
        }
    }
}
