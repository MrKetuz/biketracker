using LocationDisplayer.DataObjects;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationDisplayer
{
    public partial class MainPage : ContentPage
    {
        List<MarkerData> locations = new List<MarkerData>();
        private CancellationTokenSource _cancelTokenSource;
        bool isTracking = false;
        public MainPage()
        {
            InitializeComponent();

        }

        private async void OnTrackerStart(object sender, EventArgs e)
        {
            PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Required", "Location access is needed.", "maybe");
                return;
            }
            if (!isTracking) 
            {
                isTracking = true;

                Startbtn.Text = "Stop";

                _cancelTokenSource = new CancellationTokenSource();

                _ = StartTracking(_cancelTokenSource.Token);

            }
            else
            {
                isTracking = false;

                Startbtn.Text = "START";

                _cancelTokenSource?.Cancel();

            }

        }

        private async void OnSendData(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.PostAsJsonAsync("https://TOBEDETERMINED", locations);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Successfully sent the location data to the server!", "Cool");
                }
                else
                {
                    await DisplayAlert("Error", $"There was an error attempting to send the data. HTTP code: {response.StatusCode}", ":(");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"There was an error connecting to the backend. Exception: {ex.Message}");
            }

        }
        private async Task StartTracking(CancellationToken token)
        {
            GeolocationRequest request;
            MarkerData data = new();
            while (!token.IsCancellationRequested)
            {
                try
                {
                    request = new GeolocationRequest(GeolocationAccuracy.Best);

                    //TODO add timestamp to reference the time difference between locations taken

                    Location? location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);
                    
                    if (location != null)
                    {
                        Trace.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                        data.timestamp = DateTime.Now.ToString();
                        data.latitude = location.Latitude;
                        data.longitude = location.Longitude; 
                        
                        locations.Add(data);
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error has occured, Exception: {ex.Message}");
                }

                await Task.Delay(10000, token);

                
            }
        }

    }
}
