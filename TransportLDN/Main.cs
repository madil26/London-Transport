namespace TransportLDN
{
    public class Main
    {
        static void main(String[] args)
        {
            var getRequest = new RequestCrowding
            {
                Naptan = "940GZZLUBND",
                DayOfWeek = "WED"
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tfl.gov.uk/crowding/");

            var response = client.GetAsync($"{getRequest.Naptan}/{getRequest.DayOfWeek}").Result;

            Console.WriteLine(response);

            client.Dispose();
        }
    }
}
