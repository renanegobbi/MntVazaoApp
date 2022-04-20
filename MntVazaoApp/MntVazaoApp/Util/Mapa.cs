using Xamarin.Forms.GoogleMaps;

namespace MntVazaoApp.Util
{
    public static class Mapa
    {
        public static void AdicionarPinGoogleMaps(double latitude, 
                                                  double longitude, 
                                                  string OrganizacaoNome, 
                                                  Xamarin.Forms.GoogleMaps.Map map)
        {
            Pin pinLocation = new Pin()
            {
                Label = (OrganizacaoNome != null) ? OrganizacaoNome : "Não localizado!",
                Position = new Position(latitude, longitude),
            };

            map.Pins.Clear();
            map.Pins.Add(pinLocation);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinLocation.Position, Distance.FromMeters(1000)));
        }
    }
}


