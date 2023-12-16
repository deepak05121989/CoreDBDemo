using CoreDBDemo.Model;

namespace CoreDBDemo.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int empId);
        Task<bool> SaveEmployee(Employee employee);
        Task<bool> DeleteEmployeeById(int empId);

    }
}
