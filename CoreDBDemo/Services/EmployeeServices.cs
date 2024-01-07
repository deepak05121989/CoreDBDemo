using CoreDBDemo.Model;
using CoreDBDemo.Repository;

namespace CoreDBDemo.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository) {

            _employeeRepository = employeeRepository;
        
        }
        public async Task<bool> DeleteEmployeeById(int empId)
        {
            try
            {
                return await _employeeRepository.DeleteEmployeeById(empId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            try
            {
                return await _employeeRepository.GetEmployee(); 
            }
            catch
            {
                throw;
            }

        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            try
            {
                return await _employeeRepository.GetEmployeeById(empId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SaveEmployee( Employee employee)
        {
            try
            {
                return await _employeeRepository.SaveEmployee(employee);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch
            {
                throw;
            }
        }
    }
}
