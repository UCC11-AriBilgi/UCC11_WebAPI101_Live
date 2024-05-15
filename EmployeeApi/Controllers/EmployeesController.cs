using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")] // APInin rotalanacağı yer(syntax)
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context; 
        }



        // GET: api/<EmployeesController>
        // Kayıtları listelemek için kullanılacak HttpRequest (HttpGet)
        [HttpGet] 
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            // Burası VT tarafından çekilecek bilgileri gösteren Metot
            // 1. Employee kayıtlarımı JSON formatında VT tarafından getirme

            return Ok(await _context.Employees.ToListAsync()); // swagger'ın kendi UI gösterdi.
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")] // Format
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            // Burası VT tarafından gelecek olan id si belli bir kayıdı getirmek. Tek bir kayıt getirecek

            var employeeRecord=await _context.Employees.FindAsync(id); // üzerine gelen id bilgisine göre ilgili tablodan kayıdı getirecek

            if (employeeRecord == null) // eğer employeeRecord içeriği oluşmamışsa
            {
                return BadRequest("Çalışan kaydı bulunamadı...");
            }

            return Ok(employeeRecord); // 200 : Ok sonucu- başarılı işlem kodu
        }

        // POST api/<EmployeesController>
        [HttpPost] //Format (HttpRequest)
        public async Task<ActionResult<List<Employee>>> AddEmployee (Employee employee)
        {
            // Burası Employee tablosu üzerine yeni bir kayıt ekleyen kısım
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());

        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")] // HttpRequest ...id parametresi alıyor.
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            // Belirli bir id bilgisine göre VT tarafındaki tabloda ilgili veriyi güncelleyen bölüm.
            var record= await _context.Employees.FindAsync(request.Id);

            if (record == null) // ilgili kayıdı bulamamışsa
            {
                return BadRequest("Böyle bir çalışan bulunamadı.....");
            }

            // Kayıdı buldu...Yeni değerlerle (parametreden gelen requst bilgisi) güncelleme işlemi

            record.FName = request.FName; // kayıt yeni değerlere güncelleniyor.
            record.LName = request.LName;
            record.City= request.City;

            await _context.SaveChangesAsync(); // VT deki tabloya gönderiliyor.

            return Ok(await _context.Employees.ToListAsync()); // tablonun en son hali tekrar okunuyor.
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")] // HttpRequest .. id parametresi alıyor.
        public async Task<ActionResult<List<Employee>>> DeleteEmploye(int id)
        {
            // Belirli bir id bilgisine göre Employee tablosundan ilgili bir kayıdı silme..
            var record = await _context.Employees.FindAsync(id);

            if (record == null)
            {
                return BadRequest("Böyle bir kayıt bulunamadı...");
            }

            _context.Employees.Remove(record); // Bulduğun kayıdı tablodan sil.

            await _context.SaveChangesAsync(); // en son değişiklikleri kaydet

            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
