using CoreDBDemo.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CoreDBDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration? _configuration;
        private readonly SqlConnection? _sqlConnection;
        private readonly SqlCommand? _sqlCommand;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            try
            {
                _sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDB"));

                _sqlConnection.Open();
                _sqlCommand = new SqlCommand();

                _sqlCommand.Connection = _sqlConnection;


            }
            catch
            {
                _sqlConnection!.Close();
            }

        }

        public async Task<bool> DeleteEmployeeById(int empId)
        {
           
            try
            {
                string query = "delete  from employees where emp_id='" + empId + "'";
                // string query = "Select * from employees where emp_id=@empid";

                _sqlCommand.CommandText = query;
                SqlDataReader dr = await _sqlCommand.ExecuteReaderAsync();
                if (dr.Read())
                {
                    return true;

                }
            }
            catch
            {
                _sqlConnection!.Close();
                throw;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                string query = "Select * from employees";
                _sqlCommand.CommandText = query;
                SqlDataReader dr = await _sqlCommand.ExecuteReaderAsync();
                while (dr.Read())
                {
                    var emp = new Employee
                    {
                        EmployeeId = Convert.ToInt32(dr["emp_id"].ToString()),
                        EmployeeEmail = dr["emp_email"].ToString(),
                        EmployeeMobile = Convert.ToInt64(dr["emp_mobile"].ToString()),
                        EmployeeName = dr["emp_name"].ToString(),
                        EmployeeSalary = Convert.ToDouble(dr["emp_salary"].ToString())
                    };
                    list.Add(emp);
                }
            }
            catch
            {
                _sqlConnection!.Close();
                throw;
            }
            return list;
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            Employee? employee = null;
            try
            {
                string query = "Select * from employees where emp_id='"+empId+"'";
               // string query = "Select * from employees where emp_id=@empid";

                _sqlCommand.CommandText = query;
                SqlDataReader dr = await _sqlCommand.ExecuteReaderAsync();
                while (dr.Read())
                {
                    employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(dr["emp_id"].ToString()),
                        EmployeeEmail = dr["emp_email"].ToString(),
                        EmployeeMobile = Convert.ToInt64(dr["emp_mobile"].ToString()),
                        EmployeeName = dr["emp_name"].ToString(),
                        EmployeeSalary = Convert.ToDouble(dr["emp_salary"].ToString())
                    };
                    
                }
            }
            catch
            {
                _sqlConnection!.Close();
                throw;
            }
            return employee;
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            try
            {
                string query = "insert into employees([emp_name], [emp_email], [emp_mobile], [emp_salary]) values('"+employee.EmployeeName+"','"+employee.EmployeeEmail+"','"+employee.EmployeeMobile+"','"+employee.EmployeeSalary+"')";
                // string query = "Select * from employees where emp_id=@empid";

                _sqlCommand.CommandText = query;
                int result = await _sqlCommand.ExecuteNonQueryAsync();
                if (result>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                _sqlConnection!.Close();
                throw;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                string query = "Update employees set [emp_name]='" + employee.EmployeeName + "',[emp_email]='" + employee.EmployeeEmail + "',[emp_mobile]='" + employee.EmployeeMobile + "',[emp_salary]='" + employee.EmployeeSalary + "' where [emp_id]='" + employee.EmployeeId + "'";

                _sqlCommand.CommandText = query;
                int result = await _sqlCommand.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                _sqlConnection!.Close();
                throw;
            }
        }
    }
}
