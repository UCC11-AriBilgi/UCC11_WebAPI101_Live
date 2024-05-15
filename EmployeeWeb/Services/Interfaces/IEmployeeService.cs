using EmployeeWeb.Models;

namespace EmployeeWeb.Services.Interfaces
{
    public interface IEmployeeService
    {
        // Aslında bir şözleşme/yönerge. Sadece metot tanımları var. :çerikleri bu interfaceden türetilecek sınıflar üzerinde olacak.
        // Bu metotları birer Task olarak tanımladık. Yani proramın çalışma anında birbirinden bağımsız şekilde metotların çalışmasını sağlamak.   

        // VT üzerinden tüm kayıtları getirecek olan metot/task 
        Task<IEnumerable<Employee>> GetAll();

        // VT üzerinden id si verilen bir kaydı getirecek olan metot/task
        Task<Employee> GetById(int id);

    }
}
