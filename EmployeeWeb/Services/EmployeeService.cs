namespace EmployeeWeb.Services
{
    // Bu MVC uygulaması client(Web)/server(Api) yapısında client görevi görecek.O yüzden buraya gerekli bazı kütüphaneleri tanımlamak gerekiyor.

    public class EmployeeService
    {
        private readonly HttpClient _client; // Client
        private readonly string _APIbase; // Server --> https://<apimin bulunduğu yer> localhost:7087

        // constructor
        public EmployeeService(HttpClient client,IConfiguration configuration)
        {
            _client = client;
            _APIbase = configuration["APISection:BaseAddress"]; // appsettings.json dan gelen bilgilier.
                
        }
    }
}
