using EmployeeWeb.Models;

namespace EmployeeWeb.Services.Interfaces
{
    public interface IEmployeeService
    {
        // Aslında bir şözleşme. Sadece metot tanımları var. :çerikleri bu interfaceden türetilecek sınıflar üzerinde olacak.

        // VT üzerinden tüm kayıtları getirecek olan metot/task 
        Task<IEnumerable<Employee>> GetAll();

        // VT üzerinden id si verilen bir kaydı getirecek olan netot/task
        Task<Employee> GetById(int id);

    }
}
