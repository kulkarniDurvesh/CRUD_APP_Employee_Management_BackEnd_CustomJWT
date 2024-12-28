using Models;
using RepositoryLayer;

namespace ServiceLayer
{
    public class EmployeeServices
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeServices(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeClass>> GetAllEmployessList() { 
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<List<EmployeeClass>> GetAllEmployeesByAge(int age) {
            return await _employeeRepository.GetAllEmployeesByAge(age);
        }

        public  async Task<EmployeeDTO> AddEmployee(EmployeeClass employee) 
        {
            return await _employeeRepository.AddEmployee(employee);
        }
        public async Task<EmployeeClass> UpdateEmployeeDetails(EmployeeClass employee)
        {
            return await _employeeRepository.UpdateEmployeeDetails(employee);
        }
    }
}
