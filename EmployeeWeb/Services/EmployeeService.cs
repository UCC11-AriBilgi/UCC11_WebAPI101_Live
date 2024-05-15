using EmployeeWeb.Models;
using EmployeeWeb.Services.Interfaces;

namespace EmployeeWeb.Services
{


    public class EmployeeService : IEmployeeService
    {
        // Bu MVC uygulaması client(Web)/server(Api) yapısında client görevi görecek.O yüzden buraya gerekli bazı kütüphaneleri tanımlamak gerekiyor. API tarafım server tarzı hareket edecek.

        private readonly HttpClient _client; // Client
        private readonly string _APIbase; // Server --> https://<<APInin bulunduğu yer> localhost:7087

        // constructor
        public EmployeeService(HttpClient client,IConfiguration configuration)
        {
            _client = client;
            _APIbase = configuration["APISection:BaseAddress"]; // appsettings.json dan gelen bilgilier.
                
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            string ApiPath = _APIbase + "api/Employee";

            var response = await _client.GetAsync(ApiPath);

            return await response.ReadContentAsync<List<Employee>>();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
