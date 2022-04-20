using MntVazaoApp.Models;
using MntVazaoApp.Util;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MntVazaoApp.Droid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaView : ContentPage
    {
        private string organizacaoNome;
        public string OrganizacaoNome
        {
            get { return organizacaoNome; }
            set
            {
                organizacaoNome = value;
                OnPropertyChanged();
            }
        }

        private string organizacaoTelefone;
        public string OrganizacaoTelefone
        {
            get { return organizacaoTelefone; }
            set
            {
                organizacaoTelefone = value;
                OnPropertyChanged();
            }
        }

        private string organizacaoEmail;
        public string OrganizacaoEmail
        {
            get { return organizacaoEmail; }
            set
            {
                organizacaoEmail = value;
                OnPropertyChanged();
            }
        }

        private string localizacaoDescricao;
        public string LocalizacaoDescricao
        {
            get { return localizacaoDescricao; }
            set
            {
                localizacaoDescricao = value;
                OnPropertyChanged();
            }
        }

        private string localizacaoEndereco;
        public string LocalizacaoEndereco
        {
            get { return localizacaoEndereco; }
            set
            {
                localizacaoEndereco = value;
                OnPropertyChanged();
            }
        }

        private string localizacaoLatitude;
        public string LocalizacaoLatitude
        {
            get { return localizacaoLatitude; }
            set
            {
                localizacaoLatitude = value;
                OnPropertyChanged();
            }
        }

        private string localizacaoLongitude;
        public string LocalizacaoLongitude
        {
            get { return localizacaoLongitude; }
            set
            {
                localizacaoLongitude = value;
                OnPropertyChanged();
            }
        }

        public MapaView()
        {
            InitializeComponent();
            this.BindingContext = this;
            Mapa.AdicionarPinGoogleMaps(-20.3169498, -40.3083655, "", map);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<ObservableCollection<SensorJson>>(this, "CriarMapa",
            (Sensor) =>
            {
                OrganizacaoNome = Sensor.Last().Organizacao_Nome;
                OrganizacaoTelefone = Sensor.Last().Organizacao_Telefone;
                OrganizacaoEmail = Sensor.Last().Organizacao_Email;
                LocalizacaoDescricao = Sensor.Last().Localizacao_Descricao;
                LocalizacaoEndereco = Sensor.Last().Organizacao_Endereco;
                LocalizacaoLatitude = Sensor.Last().Localizacao_Latitude;
                LocalizacaoLongitude = Sensor.Last().Localizacao_Longitude;

                double latitude;
                double longitude;

                // posição padrão para lat e long indefinidos
                if (LocalizacaoLatitude == null || LocalizacaoLongitude == null)
                {
                    latitude = -20.3169498; 
                    longitude = -40.3083655; 
                }
                else
                {
                    latitude = double.Parse(LocalizacaoLatitude.Replace(".", ""));
                    longitude = double.Parse(LocalizacaoLongitude.Replace(".", ""));
                }

                Mapa.AdicionarPinGoogleMaps(latitude, longitude, OrganizacaoNome, map);
            });
        }
    }
}

