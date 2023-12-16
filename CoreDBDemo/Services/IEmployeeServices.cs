using CoreDBDemo.Model;

namespace CoreDBDemo.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int empId);
        Task<bool> SaveEmployee(Employee employee);
        Task<bool> DeleteEmployeeById(int empId);
    }
}
